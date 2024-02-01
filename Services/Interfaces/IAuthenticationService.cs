using WholesaleEcomBackend.Dtos;
using Microsoft.AspNetCore.Identity;

namespace WholesaleEcomBackend.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

    }
}
