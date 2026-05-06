using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Infrastructure.DataAccess.DbContexts;

namespace TvoeTiloApp.Infrastructure.DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly TvoeTiloAppDbContext context;

        public ClientRepository(TvoeTiloAppDbContext _context) 
        {
            context = _context;
        }

        public IQueryable<Client> GetAll()
        {
            return context.Clients;
        }
    }
}
