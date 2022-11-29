using System;
using System.Net;
using System.Net.Sockets;

namespace ControlDesktopDomainModel.Service.Configuration
{
    public static class ConfigurationManager
    {
        public static bool AppAuthorization
        {
            get => GeneralSettings.Default.AppAuthorization;
            set
            {
                GeneralSettings.Default.AppAuthorization = value;
                Save();
            }
        }

        public static string AppLogin
        {
            get => GeneralSettings.Default.AppLogin;
            set
            {
                GeneralSettings.Default.AppLogin = value;
                Save();
            }
        }
        public static string AppPassword
        {
            get => GeneralSettings.Default.AppPassword;
            set
            {
                GeneralSettings.Default.AppPassword = value;
                Save();
            }
        }

        public static bool AppAutoLoad
        {
            get => GeneralSettings.Default.AppAutoLoad;
            set
            {
                GeneralSettings.Default.AppAutoLoad = value;
                Save();
            }
        }

        public static bool AppAutoListening
        {
            get => GeneralSettings.Default.AppAutoListening;
            set
            {
                GeneralSettings.Default.AppAutoListening = value;
                Save();
            }
        }

        public static bool AppFirstLaunch
        {
            get => GeneralSettings.Default.AppFirstLaunch;
            set
            {
                GeneralSettings.Default.AppFirstLaunch = value;
                Save();
            }
        }

        private static void Save() => GeneralSettings.Default.Save();
    }
}