using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ControlDesktopDomainModel.Service.ProcessSystem
{
    public static class ProcessSystem
    {
        public static List<string> processes
        {
            get
            {
                Process[] processCollection = Process.GetProcesses();
                var processes = new List<string>();
                foreach (Process p in processCollection)
                {
                    processes.Add(p.ProcessName);
                }

                return processes;
            }
        }

        public static void StartProcess(string name)
        {
            //Process.Start(name);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(name)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        public static void StartProcessWithArgs(string name, string args)
        {
            Process.Start(name, args);
        }

        public static void KillProcess(string name)
        {
            foreach (Process proc in Process.GetProcessesByName(name))
            {
                proc.Kill();
            }
        }
    }
}