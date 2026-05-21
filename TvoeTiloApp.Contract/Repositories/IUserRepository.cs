using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Contract.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetActiveClients();

        Task<User> GetByIdAsync(int id);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetLoginUserAsync(string email, string passwordHash);

        Task AddAsync(User entity);

        Task UpdateAsync(User entity);
    }
}
