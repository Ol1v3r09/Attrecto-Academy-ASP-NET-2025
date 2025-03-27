using System.ComponentModel.DataAnnotations;

namespace Academy_2025.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
