using System.Net;
using System.Threading.Tasks;
using ControlDesktopDomainModel.Service.Configuration;
using ControlDesktopDomainModel.Service.View;
using ControlDesktopPresentation.Common;
using ControlDesktopPresentation.Views;

namespace ControlDesktopPresentation.Presenters
{
    public class RegisterPresenter : BasePresenter<IRegisterView>
    {
        private IRegisterService _service;
        public RegisterPresenter(IApplicationController controller, IRegisterView view, IRegisterService service) 
            : base(controller, view)
        {
            this._service = service;
            View.Register += RegisterAsync;
            View.Cancel += View.Close;

            if (ConfigurationManager.AppAuthorization)
            {
                View.ShowMessage(
                    "Ваше приложение уже зарегистрировано\nПовторная регистрация приведет к изменению учетных данных.");
                View.Login = ConfigurationManager.AppLogin;
                View.Password = ConfigurationManager.AppPassword;
            }
        }

        public async void RegisterAsync()
        {
#warning Обработать возможные ошибки с подключением

            if (ConfigurationManager.AppAuthorization)
            {
                await ChangeRegisterDataAsync();
            }
            else
            {
                await RegisterDataAsync();
            }

            
        }

        private async Task RegisterDataAsync()
        {
            var (content, statusCode) = await Task.Run(() => _service.Register(View.Login, View.Password));
            if ((int)statusCode >= 200 && (int)statusCode <= 299)
            {
                View.ShowMessage("Регистрация прошла успешно!");
                ConfigurationManager.AppLogin = View.Login;
                ConfigurationManager.AppPassword = View.Password;
                ConfigurationManager.AppAuthorization = true;
                View.Close();
            }
            else if (statusCode == HttpStatusCode.Conflict || statusCode == HttpStatusCode.BadRequest)
            {
                View.ShowMessage($"Регистрация не удалась\nПричина: {content}");
            }
            else
            {
                View.ShowMessage("Произошла ошибка сервера.\nПожалуйста попробуйте осуществить запрос позже");
            }
        }

        private async Task ChangeRegisterDataAsync()
        {
            var oldLogin = ConfigurationManager.AppLogin;
            var oldPassword = ConfigurationManager.AppPassword;

            var (content, statusCode) = await Task.Run((() =>
                _service.ChangeRegisterData(oldLogin, oldPassword, View.Login, View.Password)));
            if ((int)statusCode >= 200 && (int)statusCode <= 299)
            {
                View.ShowMessage("Регистрация прошла успешно!");
                ConfigurationManager.AppLogin = View.Login;
                ConfigurationManager.AppPassword = View.Password;
                ConfigurationManager.AppAuthorization = true;
                View.Close();
            }
            else if (statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.Conflict)
            {
                View.ShowMessage($"Регистрация не удалась\nПричина: {content}");
            }
            else if (statusCode == HttpStatusCode.NotFound)
            {
                await RegisterDataAsync();
            }
            else
            {
                View.ShowMessage("Произошла ошибка сервера.\nПожалуйста попробуйте осуществить запрос позже");
            }
        }
    }
}