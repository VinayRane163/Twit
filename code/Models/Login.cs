using System.ComponentModel.DataAnnotations;

namespace twit.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [StringLength(100, ErrorMessage = "Password can be a maximum of 100 characters.")]
        public string Password { get; set; }
    }
}
