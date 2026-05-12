using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Contract.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetLoginUserAsync(string email, string passwordHash);

        Task AddAsync(User entity);

        Task UpdateAsync(User entity);
    }
}
