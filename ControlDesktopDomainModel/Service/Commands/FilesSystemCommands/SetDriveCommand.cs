using System.Collections.Generic;
using System.Linq;
using ControlDesktopDomainModel.Service.FileSystem;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class SetDriveCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public SetDriveCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "SetDrive";
        public override void Execute(dynamic instruction)
        {
            this._commandManager._fileSystem = null;
            this._commandManager._fileSystem =
                new FileSystem.FileSystem(new Clipboard.Clipboard(), instruction.drive.ToString());
            this.SendFiles(this._commandManager);
        }
    }
}