using System;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class CopyCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public CopyCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }

        public override string Name { get; } = "Copy";
        public override void Execute(dynamic instruction)
        {
            int index = Convert.ToInt32(instruction.index.ToString());
            if (this._commandManager._fileSystem.Exist(index))
            {
                this._commandManager._fileSystem.Copy(index);
                this.SendFiles(this._commandManager, "ok_copy");
            }
            else
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "not_found");
            }
        }
    }
}