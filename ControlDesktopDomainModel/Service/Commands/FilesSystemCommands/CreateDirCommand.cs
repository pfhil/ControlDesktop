namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class CreateDirCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public CreateDirCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "CreateDir";
        public override void Execute(dynamic instruction)
        {
            string name = instruction.dirName.ToString();
            if (!this._commandManager._fileSystem.ExistInFolder(name))
            {
                this._commandManager._fileSystem.CreateDir(name);
                this.SendFiles(this._commandManager);
            }
            else
            {
                this._commandManager._fileSystem.Refresh();
                this.SendFiles(this._commandManager, "already_exist");
            }
        }
    }
}