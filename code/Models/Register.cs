using System.ComponentModel.DataAnnotations;

namespace twit.Models
{
    public class Register
    {
        [Required]
        [MinLength(4, ErrorMessage = "name must be at least 4 characters long.")]
        [StringLength(100, ErrorMessage = "name be a maximum of 50 characters.")]
        public string Username { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [StringLength(100, ErrorMessage = "Password can be a maximum of 100 characters.")]
        public string Password { get; set; }
    }
}
