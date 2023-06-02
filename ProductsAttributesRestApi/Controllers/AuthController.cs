using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Exceptions;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Services;

namespace ProductsAttributesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly static string WRONG_PASSWORDS = "Passwords do not match.";

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponse>> Register([FromBody] UserRequest userRequest)
        {
            if (userRequest is null || !ModelState.IsValid)
                return BadRequest();

            if (!userRequest.Password.Equals(userRequest.RepeatedPassword))
            {
                return BadRequest(WRONG_PASSWORDS);
            }

            try
            {
                var result = await _authService.RegisterUser(userRequest);
                return Ok(result);
            }
            catch(AuthException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest userLoginRequest)
        {
            if (userLoginRequest is null || !ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _authService.LoginUser(userLoginRequest);
                return Ok(result);
            }
            catch(AuthException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
