using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;
using ProductsAttributesRestApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsAttributesRestApi.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IUsersRepository usersRepository, IMapper mapper, IConfiguration configuration)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<List<UserResponse>> RegisterUser(UserRequest userRequest)
    {
        if (await _usersRepository.GetUserByEmail(userRequest.Email) != null)
        {
            //vec je registrovan
            return null;
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);

        var user = _mapper.Map<User>(userRequest);
        user.PasswordHash = passwordHash;

        var result = await _usersRepository.AddUser(user);
        return _mapper.Map<List<UserResponse>>(result);
    }

    public async Task<AuthResponse> LoginUser(AuthRequest userLoginRequest)
    {
        var user = await _usersRepository.GetUserByEmail(userLoginRequest.Email);

        // there is no registered user with entered email or entered password is incorrect
        if (user is null || !BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, user.PasswordHash))
        {
            return null;
        }

        var token = CreateToken(user);
        return new AuthResponse() { Token = token };
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(JwtRegisteredClaimNames.Sub, "User ID: " + user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.FirstName + " " + user.LastName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jwt id - unique identifier at for the jwt
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()) // issued at - the time at which the jwt was issued
        };

        var expirationDate = DateTime.Now.AddDays(1);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("JwtConfig:SecretKey").Value!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: expirationDate,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
