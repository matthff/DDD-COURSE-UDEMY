using System.ComponentModel.DataAnnotations;

namespace DDD_Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is a required field for login")]
        [EmailAddress(ErrorMessage = "Email is in a invalid format")]
        [StringLength(100, ErrorMessage = "Email must have {1} characters at max")]
        public string Email { get; set; }
    }
}
