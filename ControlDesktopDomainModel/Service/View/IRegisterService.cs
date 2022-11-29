using System.Net;
using System.Threading.Tasks;

namespace ControlDesktopDomainModel.Service.View
{
    public interface IRegisterService
    {
        public Task<(string, HttpStatusCode)> Register(string login, string password);

        public Task<(string, HttpStatusCode)> ChangeRegisterData(string oldLogin, string oldPassword, string newLogin,
            string newPassword);
    }
}