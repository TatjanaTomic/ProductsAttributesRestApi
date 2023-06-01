﻿using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Services;

namespace ProductsAttributesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly static string WRONG_PASSWORDS = "Passwords do not match.";
        private readonly static string WRONG_CREDENTIALS = "Wrong email or password.";
        private readonly static string EMAIL_TAKEN = "Email is already in use.";

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UserResponse>>> Register([FromBody] UserRequest userRequest)
        {
            if (userRequest is null || !ModelState.IsValid)
                return BadRequest();

            if (!userRequest.Password.Equals(userRequest.RepeatedPassword))
            {
                return BadRequest(WRONG_PASSWORDS);
            }

            var result = await _authService.RegisterUser(userRequest);

            if (result is null)
                return BadRequest(EMAIL_TAKEN);

            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest userLoginRequest)
        {
            if (userLoginRequest is null || !ModelState.IsValid)
                return BadRequest();

            var result = await _authService.LoginUser(userLoginRequest);

            if (result is null)
                return BadRequest(WRONG_CREDENTIALS);

            return Ok(result);
        }
    }
}
