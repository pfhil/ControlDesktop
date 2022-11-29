using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDesktopDomainModel.Service.View;
using ControlDesktopPresentation.Common;
using ControlDesktopPresentation.Presenters;
using ControlDesktopPresentation.Views;

namespace ControlDesktopUI
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var controller = new ApplicationController(new LightInjectAdapder())
                    .RegisterView<IMainView, MainForm>()
                    .RegisterService<IMainService, MainService>()
                    .RegisterView<IRegisterView, RegisterForm>()
                    .RegisterService<IRegisterService, RegisterService>()
                    .RegisterInstance(new ApplicationContext());

                controller.Run<MainPresenter>();
            }
            else
            {
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}
