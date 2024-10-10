using System.ComponentModel.DataAnnotations;

namespace twit.Models
{
    public class ChangePasss
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [StringLength(100, ErrorMessage = "Password can be a maximum of 100 characters.")]
        public string NewPass{ get; set; }

        [Compare("NewPass",ErrorMessage ="password doesnt match")]
        public string ConfirmPass{ get; set; }
    }
}
