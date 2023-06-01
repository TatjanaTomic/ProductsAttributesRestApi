using ProductsAttributesRestApi.Models.Dtos;

namespace ProductsAttributesRestApi.Services
{
    public interface IAuthService
    {
        Task<List<UserResponse>> RegisterUser(UserRequest userRequest);
        Task<AuthResponse> LoginUser(AuthRequest userLoginRequest);
    }
}
