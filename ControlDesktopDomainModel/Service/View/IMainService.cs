using System;

namespace ControlDesktopDomainModel.Service.View
{
    public interface IMainService
    {
        event Action StopListeningEvent;
        void InvokeStopListeningEvent();
        void StartListening();
        void StopListening();
        void EnableAutoLoad();
        void DisableAutoLoad();
        bool CheckForInternetConnection(int timeoutMs = 10000, string url = null);
    }
}