using System;
using System.Timers;

namespace ControlDesktopDomainModel.Service.ApiProvider
{
    public interface IListener
    {
        public void Listening(Object source, ElapsedEventArgs e);
        event Action<dynamic> GetData;
    }
}