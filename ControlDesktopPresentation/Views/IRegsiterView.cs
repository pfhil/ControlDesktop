using System;
using ControlDesktopPresentation.Common;

namespace ControlDesktopPresentation.Views
{
    public interface IRegisterView : IView
    {
        public string Login { get; set; }
        public string Password { get; set; }
        event Action Register;
        event Action Cancel;
    }
}