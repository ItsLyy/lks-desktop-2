using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required!")]
        [EmailAddress(ErrorMessage = "This field required email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
