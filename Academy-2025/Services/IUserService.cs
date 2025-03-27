using Academy_2025.Data;
using Academy_2025.DTOs;

namespace Academy_2025.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDTO data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<List<UserDTO>> GetUsersAbove18Async();
        Task<UserDTO?> UpdateAsync(int id, UserDTO data);
    }
}
