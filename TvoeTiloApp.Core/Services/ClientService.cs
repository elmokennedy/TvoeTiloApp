using AutoMapper;
using AutoMapper.QueryableExtensions;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<ClientResponse> GetAll()
        {
            return _repository
                .GetAll()
                .ProjectTo<ClientResponse>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
