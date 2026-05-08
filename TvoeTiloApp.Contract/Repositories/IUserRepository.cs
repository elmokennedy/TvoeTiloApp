using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Contract.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetLoginUser(string email, string passwordHash);
    }
}
