using System.Collections.Generic;
using System.Linq;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class ChangeDirToParentCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public ChangeDirToParentCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "ChangeDirToParent";
        public override void Execute(dynamic instruction)
        {
            if (_commandManager._fileSystem.ChangeDirectoryToParent())
            {
                this.SendFiles(this._commandManager);
            }
            else
            {
                this.SendFiles(this._commandManager, "top");
            }
        }
    }
}