using AutoMapper;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Core.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Client, ClientResponse>();
        }
    }
}
