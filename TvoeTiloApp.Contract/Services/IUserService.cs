using TvoeTiloApp.Model.Requests;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Contract.Services
{
    public interface IUserService
    {
        Task<UserLoginResponse> GetLoginUser(UserLoginRequest request);
    }
}
