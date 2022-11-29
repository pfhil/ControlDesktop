using System;
using System.IO;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class ZipCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public ZipCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }

        public override string Name { get; } = "Zip";
        public override void Execute(dynamic instruction)
        {
            int index = Convert.ToInt32(instruction.index.ToString());
            string name = instruction.name.ToString();
            if (!this._commandManager._fileSystem.Exist(index))
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "not_found");
                return;
            }
            if (this._commandManager._fileSystem.ExistInFolder(name))
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "already_exist");
                return;
            }

            this._commandManager._fileSystem.Zip(index, name);
            this.SendFiles(this._commandManager);
        }
    }
}