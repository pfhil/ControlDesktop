using System;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json.Linq;

namespace ControlDesktopDomainModel.Service.ApiProvider
{
    public class CommandListener : IListener
    {
        private readonly string _login;
        private readonly string _password;
        public event Action<dynamic> GetData;
        public CommandListener(string login, string password)
        {
            this._login = login;
            this._password = password;
        }

        public void Listening(Object source, ElapsedEventArgs e)
        {
            var (json, status) = Task.Run(() => ApiMediator.GetCommand(this._login, this._password)).Result;
            if (status == HttpStatusCode.OK)
            {
                try
                { 
                    dynamic data = JObject.Parse(json);
                    GetData?.Invoke(data);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    dynamic data = JArray.Parse(json)[0];
                    GetData?.Invoke(data);
                }
            }
        }
    }
}