using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos
{
    public class UserForRegistrationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init;}

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }

    }
}
