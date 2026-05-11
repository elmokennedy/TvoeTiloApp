using AutoMapper;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Domain.Entities;
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

        public List<UserResponse> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<List<UserResponse>>(users);
        }

        public async Task<UserLoginResponse> GetLoginUser(UserLoginRequest request)
        {
            var user = await _repository.GetLoginUserAsync(request.Email, request.Password);
            //if (user is null)
            //    throw new Exception("User not found");

            return _mapper.Map<UserLoginResponse>(user);
        }

        public async Task CreateClientUser(CreateClientUserRequest request)
        {
            var user = await _repository.GetUserByEmailAsync(request.Email);
            //if (user is not null)
            //    throw new Exception("User with this Email already exists!");

            var clientUser = _mapper.Map<User>(request);
            clientUser.ClientProfile = new ClientProfile();

            await _repository.AddAsync(clientUser);
        }
    }
}
