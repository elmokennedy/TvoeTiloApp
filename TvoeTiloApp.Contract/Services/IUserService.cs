using TvoeTiloApp.Model.Requests;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Contract.Services
{
    public interface IUserService
    {
        List<UserResponse> GetAll();

        Task<UserLoginResponse> GetLoginUser(UserLoginRequest request);

        Task CreateClientUser(CreateClientUserRequest request);

        Task UpdateClientUser(UpdateClientUserRequest request);
    }
}
