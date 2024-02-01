using WholesaleEcomBackend.Dtos;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleEcomBackend.Controllers
{

    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration is null)
            {
                return BadRequest("UserForRegistrationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }


            var result = await _authenticationService.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);

            }
            return StatusCode(201);

        }


        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (userForAuthenticationDto is null)
            {
                return BadRequest("userForAuthenticationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            if (!await _authenticationService.ValidateUser(userForAuthenticationDto))
                return Unauthorized();

            return Ok(new { Token = await _authenticationService.CreateToken()});
        }


    }
}
