using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Contract.Services
{
    public interface IClientService
    {
        List<ClientResponse> GetAll();
    }
}
