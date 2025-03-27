using Academy_2025.DTOs;

namespace Academy_2025.Services
{
    public interface ICourseService
    {
        Task CreateAsync(CourseDTO data);
        Task<bool> DeleteAsync(int id);
        Task<List<CourseDTO>> GetAllAsync();
        Task<CourseDTO?> GetByIdAsync(int id);
        Task<CourseDTO?> UpdateAsync(int id, CourseDTO data);
    }
}
