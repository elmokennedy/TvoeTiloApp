using Microsoft.EntityFrameworkCore;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Infrastructure.DataAccess.DbContexts;

namespace TvoeTiloApp.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TvoeTiloAppDbContext context;

        public UserRepository(TvoeTiloAppDbContext _context)
        {
            context = _context;
        }

        public IQueryable<User> GetAll()
        {
            return context.Users;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetLoginUserAsync(string email, string passwordHash)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
        }

        public async Task AddAsync(User entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
