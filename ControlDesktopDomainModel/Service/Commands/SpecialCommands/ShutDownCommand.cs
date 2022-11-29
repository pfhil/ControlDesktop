using System.Collections.Generic;

namespace ControlDesktopDomainModel.Service.Commands.SpecialCommands
{
    public class ShutDownCommand : Command
    {
        public override string Name { get; } = "ShutDown";
        public override void Execute(dynamic instruction)
        {
            var report = new Dictionary<string, dynamic>
            {
                {"command_state", "ok_shut_down"}
            };
            this.Report(report);
            ProcessSystem.ProcessSystem.StartProcessWithArgs("shutdown", "/s /t 0");
        }
    }
}