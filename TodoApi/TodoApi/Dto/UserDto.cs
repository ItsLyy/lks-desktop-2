using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Please fill your email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
