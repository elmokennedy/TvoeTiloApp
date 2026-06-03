using AutoMapper;
using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Domain.Entities;
using TvoeTiloApp.Domain.Enums;
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

        public List<UserResponse> GetActiveClients()
        {
            var users = _repository.GetActiveClients();
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
            if (user is not null)
                throw new Exception("User with this Email already exists!");

            var clientUser = _mapper.Map<User>(request);
            clientUser.UserRole = UserRole.Client;
            clientUser.ClientProfile = new ClientProfile();
            clientUser.PasswordHash = "defaultpasswordhash";
            clientUser.IsActive = true;

            await _repository.AddAsync(clientUser);
        }

        public async Task UpdateClientUser(int userId, UpdateClientUserRequest request)
        {
            var user = await _repository.GetByIdAsync(userId);
            //if (user is null)
            //    throw new Exception("User with this ID doesn't exist!");

            //var user = await _repository.GetUserByEmailAsync(request.Email);
            //if (user is not null)
            //    throw new Exception("User with this Email already exists!");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteClientUser(int userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            //if (user is null)
            //    throw new Exception("User with this ID doesn't exist!");

            user.IsActive = false;

            await _repository.UpdateAsync(user);
        }
    }
}
