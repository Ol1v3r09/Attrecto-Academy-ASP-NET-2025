using Academy_2025.Data;

namespace Academy_2025.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course data);
        bool Delete(int id);
        List<Course> GetAll();
        Course? GetById(int id);
        Course? Update(int id, Course data);
    }
}