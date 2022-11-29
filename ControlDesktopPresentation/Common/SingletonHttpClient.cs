using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesktopPresentation.Common
{
    public class SingletonHttpClient : HttpClient
    {
        private SingletonHttpClient() { }
        private static SingletonHttpClient _instance;
        public static SingletonHttpClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonHttpClient();
            }
            return _instance;
        }

    }
}
