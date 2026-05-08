using AutoMapper;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Model.Requests;
using TvoeTiloApp.Model.Responses;

namespace TvoeTiloApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserLoginResponse> GetLoginUser(UserLoginRequest request)
        {
            var user = await _repository.GetLoginUser(request.Email, request.Password);
            //if (user is null)
            //    throw new Exception("User not found");

            return _mapper.Map<UserLoginResponse>(user);
        }
    }
}
