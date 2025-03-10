using Academy_2025.Data;

namespace Academy_2025.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetUsersAbove18Async();
        Task<User?> UpdateAsync(int id, User data);
    }
}