using System;

namespace ControlDesktopDomainModel.Service.Commands.ProcessSystemCommands
{
    public class KillProcessCommand : ProcessSystemCommand
    {
        public override string Name { get; } = "KillProcess";
        public override void Execute(dynamic instruction)
        {
            try
            {
                ProcessSystem.ProcessSystem.KillProcess(instruction.name.ToString());
                this.SendProcesses();
            }
            catch
            {
                this.SendProcesses("not_found");
            }
        }
    }
}