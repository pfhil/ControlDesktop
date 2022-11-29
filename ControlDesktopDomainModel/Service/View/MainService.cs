
using System;
using System.Globalization;
using System.Net;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Commands;
using ControlDesktopDomainModel.Service.Configuration;
using Microsoft.Win32;

namespace ControlDesktopDomainModel.Service.View
{
    public class MainService : IMainService
    {
        private CommandManager _commandManager;
        public event Action StopListeningEvent;

        public void StartListening()
        {
            this._commandManager =
                new CommandManager(new CommandListener(ConfigurationManager.AppLogin,
                    ConfigurationManager.AppPassword), this);
            this._commandManager.StartListening();
        }

        public void StopListening()
        {
            this._commandManager?.StopListening();
            this._commandManager = null;
        }

        public void InvokeStopListeningEvent()
        {
            this.StopListeningEvent?.Invoke();
        }

        public void EnableAutoLoad()
        {
            //const string applicationName = "testProgram";
            //const string pathRegistryKeyStartup =
            //    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            //using (RegistryKey registryKeyStartup =
            //    Registry.LocalMachine.OpenSubKey(pathRegistryKeyStartup, true))
            //{
            //    registryKeyStartup.SetValue(
            //        applicationName,
            //        string.Format("\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
            //}
        }

        public void DisableAutoLoad()
        {
            const string applicationName = "testProgram";
            const string pathRegistryKeyStartup =
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            using (RegistryKey registryKeyStartup =
                Registry.LocalMachine.OpenSubKey(pathRegistryKeyStartup, true))
            {
                registryKeyStartup.DeleteValue(applicationName, false);
            }
        }

        public bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using var response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}