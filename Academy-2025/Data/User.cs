using System.ComponentModel.DataAnnotations;

namespace Academy_2025.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public int Age { get; set; }
        public string? Role { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
