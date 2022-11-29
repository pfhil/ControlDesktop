namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class MoveCommand : FileSystemCommand
    {
        public override string Name { get; } = "Move";

        private CommandManager _commandManager;

        public MoveCommand(CommandManager commandManager)
        {
            this._commandManager = commandManager;
        }
        public override void Execute(dynamic instruction)
        {
            this._commandManager._fileSystem.Move();
            this.SendFiles(this._commandManager);
        }
    }
}