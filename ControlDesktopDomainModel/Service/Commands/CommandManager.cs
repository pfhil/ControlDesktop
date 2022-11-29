using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Commands.FilesSystemCommands;
using ControlDesktopDomainModel.Service.Commands.ProcessSystemCommands;
using ControlDesktopDomainModel.Service.Commands.SpecialCommands;
using ControlDesktopDomainModel.Service.FileSystem;
using ControlDesktopDomainModel.Service.View;

namespace ControlDesktopDomainModel.Service.Commands
{
    public class CommandManager
    {
        private List<Command> _commandList;
        private IListener _listener;
        internal IFileSystem _fileSystem;
        private Timer _listeningTimer;
        internal MainService _mainService;

        public CommandManager(IListener listener, MainService mainService)
        {
            this._listener = listener;
            this._listener.GetData += (json => Execute(json));

            this._listeningTimer = new Timer(2500);
            _listeningTimer.Elapsed += (this._listener.Listening);

            this._mainService = mainService;

            _commandList = new List<Command>()
            {
                new GetStatusCommand(),
                new GetDrivesCommand(),
                new SetDriveCommand(this),
                new ChangeDirToChildCommand(this),
                new ChangeDirToParentCommand(this),
                new CreateFileCommand(this),
                new CreateDirCommand(this),
                new DeleteCommand(this),
                new ZipCommand(this),
                new CopyCommand(this),
                new PasteCommand(this),
                new SendFileCommand(this),
                new RenameCommand(this),
                new MoveCommand(this),

                new GetProcessesCommand(),
                new KillProcessCommand(),
                new StartProcess(),

                new SendScreenShotCommand(),
                new ShutDownCommand(),
                new StopListeningCommand(this),
            };
        }

        public void StartListening()
        {
            this._listeningTimer.Start();
        }

        public void StopListening()
        {
            this._listeningTimer.Stop();
        }

        private void Execute(dynamic json)
        {
            var command = _commandList.FirstOrDefault(_command => _command.Name == json.command.ToString());

            if (command != null)
            {
                command.Execute(json);
            }
        }

    }
}