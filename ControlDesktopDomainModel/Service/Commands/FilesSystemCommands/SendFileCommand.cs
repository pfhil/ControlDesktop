using System;
using System.Collections.Generic;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class SendFileCommand : FileSystemCommand
    {
        private CommandManager _commandManager;

        public SendFileCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "SendFile";
        public override void Execute(dynamic instruction)
        {
            int index = Convert.ToInt32(instruction.index.ToString());
            if (this._commandManager._fileSystem.Exist(index))
            {
                var fileName = this._commandManager._fileSystem.SendFile(index);

                var (files, dirs) = this.GetFilesAndDirs(this._commandManager);

                var report = new Dictionary<string, dynamic>
                {
                    {"command_state", "ok_send"},
                    {"current_dir", this._commandManager._fileSystem.CurrentDirectory},
                    {"dirs", dirs},
                    {"files", files},
                    {"file_name", fileName.ToString()}
                };
                this.Report(report);
            }
            else
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "not_found");
            }

        }
    }
}