using Microsoft.EntityFrameworkCore;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Domain.Enums;
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

        public IQueryable<User> GetActiveClients()
        {
            return context.Users.Where(x => x.UserRole == UserRole.Client && x.IsActive);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
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

        public async Task UpdateAsync(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
