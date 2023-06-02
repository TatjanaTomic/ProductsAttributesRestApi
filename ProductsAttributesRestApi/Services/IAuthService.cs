using ProductsAttributesRestApi.Models.Dtos;

namespace ProductsAttributesRestApi.Services
{
    public interface IAuthService
    {
        Task<UserResponse> RegisterUser(UserRequest userRequest);
        Task<AuthResponse> LoginUser(AuthRequest userLoginRequest);
    }
}
