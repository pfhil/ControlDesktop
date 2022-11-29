using System;
using System.Collections.Generic;

namespace ControlDesktopDomainModel.Service.Commands
{
    public class GetStatusCommand : Command
    {
        public override string Name { get; } = "GetStatus";
        public override void Execute(dynamic instruction)
        {
            var workingTime = "";

            workingTime += (Environment.TickCount / 86400000) + " дней, ";
            workingTime += (Environment.TickCount / 3600000 % 24) + " часов, ";
            workingTime += (Environment.TickCount / 120000 % 60) + " минут, ";
            workingTime += (Environment.TickCount / 1000 % 60) + " секунд.";

            var report = new Dictionary<string, dynamic>
            {
                { "command_state", "ok" },
                { "state", "listening"},
                { "computer_work_time", workingTime }
            };

            this.Report(report);
        }

    }
}