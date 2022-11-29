using System.Collections.Generic;

namespace ControlDesktopDomainModel.Service.Commands.ProcessSystemCommands
{
    public abstract class ProcessSystemCommand : Command
    {
        protected virtual void SendProcesses(string state = "ok")
        {
            var report = new Dictionary<string, dynamic>
            {
                {"command_state", state},
                {"processes", ProcessSystem.ProcessSystem.processes}
            };
            this.Report(report);
        }
    }
}