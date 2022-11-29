namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class CreateFileCommand : FileSystemCommand

    {
        private CommandManager _commandManager;
        public CreateFileCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override string Name { get; } = "CreateFile";
        public override void Execute(dynamic instruction)
        {
            string name = instruction.fileName.ToString();
            if (!this._commandManager._fileSystem.ExistInFolder(name))
            {
                this._commandManager._fileSystem.CreateFile(name);
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