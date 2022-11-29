namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class PasteCommand : FileSystemCommand
    {
        private CommandManager _commandManager;
        public PasteCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }

        public override string Name { get; } = "Paste";
        public override void Execute(dynamic instruction)
        {
            this._commandManager._fileSystem.Paste();
            this.SendFiles(this._commandManager);
        }
    }
}