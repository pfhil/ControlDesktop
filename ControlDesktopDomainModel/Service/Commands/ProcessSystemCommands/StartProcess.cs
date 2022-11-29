using System;

namespace ControlDesktopDomainModel.Service.Commands.ProcessSystemCommands
{
    public class StartProcess : ProcessSystemCommand
    {
        public override string Name { get; } = "StartProcess";
        public override void Execute(dynamic instruction)
        {
            try
            {
                ProcessSystem.ProcessSystem.StartProcess(instruction.name.ToString());
                this.SendProcesses();
            }
            catch
            {
                this.SendProcesses("not_found");
            }
        }
    }
}