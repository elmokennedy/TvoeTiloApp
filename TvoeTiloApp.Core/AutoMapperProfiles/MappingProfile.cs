using AutoMapper;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Core.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ClientProfile, ClientResponse>();
            CreateMap<User, UserLoginResponse>();
        }
    }
}
