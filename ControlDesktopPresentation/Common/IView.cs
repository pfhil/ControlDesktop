using System;
using System.Collections.Generic;
using System.Text;

namespace ControlDesktopPresentation.Common
{
    public interface IView
    {
        void Show();
        void Close();
        void ShowMessage(string message);
    }
}
