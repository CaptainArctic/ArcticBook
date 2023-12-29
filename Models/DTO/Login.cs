using System.ComponentModel.DataAnnotations;

namespace ArcticBook.Models.DTO
{
    public class Login
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
