using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;

namespace Academy_2025.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task CreateAsync(UserDTO data)
            => _repository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(x => MapToDTO(x)).ToList();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user != null ? MapToDTO(user) : null;
        }

        public async Task<UserDTO?> UpdateAsync(int id, UserDTO data)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user != null) 
            {
                user.Name = data.Name;
                user.Age = data.Age;
                user.Role = data.Role;

                await _repository.UpdateAsync();
            }

            return user != null ? MapToDTO(user) : null;
        }
        public Task<List<UserDTO>> GetUsersAbove18Async()
        {
            throw new NotImplementedException();
        }

        private static User MapToModel(UserDTO data)
        {
            User user = new User{Email="email", Password="password"};
            user.Id = data.Id;
            user.Name = data.Name;
            user.Age = data.Age;
            user.Role = data.Role;
            user.Email = data.Email;
            user.Password = data.Password;
            return user;
        }
        private static UserDTO MapToDTO(User data)
        {
            UserDTO user = new UserDTO{Email = "email", Password = "password" };
            user.Id = data.Id;
            user.Name = data.Name;
            user.Age = data.Age;
            user.Role = data.Role;
            user.Email = data.Email;
            user.Password = data.Password;
            return user;
        }
    }
}
