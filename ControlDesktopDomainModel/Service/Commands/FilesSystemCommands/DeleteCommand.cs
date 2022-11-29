using System;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class DeleteCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public DeleteCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "Delete";
        public override void Execute(dynamic instruction)
        {
            int index = Convert.ToInt32(instruction.index.ToString());
            if (this._commandManager._fileSystem.Exist(index))
            {
                this._commandManager._fileSystem.Delete(index);
                this.SendFiles(this._commandManager);
            }
            else
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "not_found");
            }
        }
    }
}