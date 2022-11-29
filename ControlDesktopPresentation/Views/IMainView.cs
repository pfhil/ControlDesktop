using System;
using ControlDesktopPresentation.Common;

namespace ControlDesktopPresentation.Views
{
    public interface IMainView : IView
    {
        public string ExecutablePath { get; }
        public bool AutoLoadApp { get; set; }
        public bool ListeningServer { get; set; }
        public bool AutoListeningServer { get; set; }
        event Action ShowAccountManagerView;
        event Action ShowAboutView;
        event Action ToggleAutoLoadApp;
        event Action ToggleListeningServer;
        event Action ToggleAutoListeningServer;
        event Action TryUnblockInternetFunctionality;
        event Action FormActivated;
        void ShowTutorial();
        void BlockInternetFunctionality();
        void UnblockInternetFunctionality();
        void BlockListeningServerButton();
        void UnBlockListeningServerButton();
        void StopListening();
    }
}