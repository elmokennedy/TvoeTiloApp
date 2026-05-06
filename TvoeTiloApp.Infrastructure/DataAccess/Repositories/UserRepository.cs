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

        public async Task<User> GetLoginUser(string email, string passwordHash)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}
