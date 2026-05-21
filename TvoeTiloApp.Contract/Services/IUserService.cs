using TvoeTiloApp.Model.Requests;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Contract.Services
{
    public interface IUserService
    {
        List<UserResponse> GetActiveClients();

        Task<UserLoginResponse> GetLoginUser(UserLoginRequest request);

        Task CreateClientUser(CreateClientUserRequest request);

        Task UpdateClientUser(int userId, UpdateClientUserRequest request);

        Task DeleteClientUser(int userId);
    }
}
