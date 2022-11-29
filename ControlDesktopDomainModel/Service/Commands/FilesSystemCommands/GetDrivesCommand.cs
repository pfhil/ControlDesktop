using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ControlDesktopDomainModel.Service.Commands.FilesSystemCommands
{
    public class GetDrivesCommand : FileSystemCommand
    {
        public override string Name { get; } = "GetDrives";
        public override void Execute(dynamic instruction)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            var availableDrives = new List<string>();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    availableDrives.Add(d.Name);
                }
            }
            if (availableDrives.Any())
            {
                var report = new Dictionary<string, dynamic>
                {
                    { "command_state", "ok" },
                    { "drives", availableDrives }
                };
                this.Report(report);
            }
            else
            {
                var report = new Dictionary<string, dynamic>
                {
                    { "command_state", "no_drives" }
                };
                this.Report(report);
            }
        }
    }
}