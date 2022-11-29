using System;
using System.Globalization;
using System.Net;
using ControlDesktopPresentation.Common;
using ControlDesktopPresentation.Views;
using ControlDesktopDomainModel.Service.Configuration;
using ControlDesktopDomainModel.Service.View;

namespace ControlDesktopPresentation.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IMainService _service;
        public MainPresenter(IApplicationController controller, IMainView view, IMainService service) 
            : base(controller, view)
        {
            this._service = service;
            StartApp();

            View.ShowAccountManagerView += StopListeningServer;
            View.ShowAccountManagerView += controller.Run<RegisterPresenter>;

            View.ToggleAutoLoadApp += ToggleAutoLoadApp;

            View.ToggleAutoListeningServer += ToggleAutoListeningServer;

            View.ToggleListeningServer += ToggleListeningServer;

            View.TryUnblockInternetFunctionality += TryUnblockInternetConnection;

            View.FormActivated += () =>
            {
                if (ConfigurationManager.AppAuthorization)
                {
                    View.UnBlockListeningServerButton();
                }
                else
                {
                    View.BlockListeningServerButton();
                }
            };

            _service.StopListeningEvent += (() =>
            {
                View.StopListening();
                _service.StopListening();
            });
        }

        private void TryUnblockInternetConnection()
        {
            if (this._service.CheckForInternetConnection())
            {
                View.UnblockInternetFunctionality();
                if (ConfigurationManager.AppAuthorization)
                {
                    View.UnBlockListeningServerButton();
                }
                else
                {
                    View.BlockListeningServerButton();
                }
            }
            else
            {
                View.ShowMessage("Не удалось восстановить подключение к интернету");
            }
        }

        private void StopListeningServer()
        {

            _service.StopListening();

            View.ListeningServer = false;
        }

        private void ToggleListeningServer()
        {
            if (View.ListeningServer)
            {
                _service.StopListening();
            }
            else
            {
                _service.StartListening();
            }

            View.ListeningServer = !View.ListeningServer;
        }

        private void ToggleAutoListeningServer()
        {
            View.AutoListeningServer = !View.AutoListeningServer;
            ConfigurationManager.AppAutoListening = View.AutoListeningServer;
        }

        private void ToggleAutoLoadApp()
        {
            //if (View.AutoLoadApp)
            //{
            //    _service.DisableAutoLoad();
            //}
            //else
            //{
            //    _service.EnableAutoLoad();
            //}

            View.AutoLoadApp = !View.AutoLoadApp;
            ConfigurationManager.AppAutoLoad = View.AutoLoadApp;
        }

        private void StartApp()
        {
            if (ConfigurationManager.AppFirstLaunch)
            {
                View.ShowTutorial();
                ConfigurationManager.AppFirstLaunch = false;
            }

            View.AutoLoadApp = ConfigurationManager.AppAutoLoad;

            if (!this._service.CheckForInternetConnection())
            {
                View.BlockInternetFunctionality();
                return;
            }

            if (!ConfigurationManager.AppAuthorization)
            {
                View.BlockListeningServerButton();
            }

            if (ConfigurationManager.AppAutoListening)
            {
                View.AutoListeningServer = true;
                if (ConfigurationManager.AppAuthorization)
                {
                    _service.StartListening();
                    View.ListeningServer = true;
                }
            }
            else
            {
                View.ListeningServer = false;
                View.AutoListeningServer = false;
            }
        }
    }
}
