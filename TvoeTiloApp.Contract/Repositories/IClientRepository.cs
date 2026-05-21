using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Contract.Repositories
{
    public interface IClientRepository
    {
        IQueryable<ClientProfile> GetAll();
    }
}
