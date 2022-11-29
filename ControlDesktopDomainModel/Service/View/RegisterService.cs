using System.Net;
using System.Threading.Tasks;
using ControlDesktopDomainModel.Service.ApiProvider;

namespace ControlDesktopDomainModel.Service.View
{
    public class RegisterService : IRegisterService
    {
        public Task<(string, HttpStatusCode)> Register(string login, string password)
        {
            return ApiMediator.Register(login, password);
        }

        public Task<(string, HttpStatusCode)> ChangeRegisterData(string oldLogin, string oldPassword, string newLogin,
            string newPassword)
        {
            return ApiMediator.ChangeRegisterData(oldLogin, oldPassword, newLogin, newPassword);
        }
    }
}