using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Academy_2025.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }
        public Task CreateAsync(CourseDTO data)
            => _repository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();
            return courses.Select(x => MapToDTO(x)).ToList();
        }

        public async Task<CourseDTO?> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return course != null ? MapToDTO(course) : null;
        }

        public async Task<CourseDTO?> UpdateAsync(int id, CourseDTO data)
        {
            var course = await _repository.GetByIdAsync(id);
            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;
                course.Author = data.Author;

                await _repository.UpdateAsync(course.Id, course);
            }

            return course != null ? MapToDTO(course) : null;
        }

        private static Course MapToModel(CourseDTO data)
        {
            Course course = new Course();
            course.Id = data.Id;
            course.Name = data.Name;
            course.Description = data.Description;
            course.Author = data.Author;
            return course;
        }
        private static CourseDTO MapToDTO(Course data)
        {
            CourseDTO course = new CourseDTO();
            course.Id = data.Id;
            course.Name = data.Name;
            course.Description = data.Description;
            course.Author = data.Author;
            return course;
        }
    }
}
