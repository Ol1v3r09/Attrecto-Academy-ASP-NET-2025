using Academy_2025.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy_2025.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> UpdateAsync(int id, Course data)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course.Id == id)
            {
                course.Name = data.Name;
                course.Description = data.Description;
                course.Author = data.Author;

                await _context.SaveChangesAsync();

                return course;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course.Id == id)
            {
                _context.Courses.Remove(course);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
