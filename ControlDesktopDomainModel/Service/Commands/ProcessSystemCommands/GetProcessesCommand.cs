namespace ControlDesktopDomainModel.Service.Commands.ProcessSystemCommands
{
    public class GetProcessesCommand : ProcessSystemCommand
    {
        public override string Name { get; } = "GetProcesses";
        public override void Execute(dynamic instruction)
        {
            this.SendProcesses();
        }
    }
}