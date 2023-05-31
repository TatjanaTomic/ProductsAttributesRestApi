using ProductsAttributesRestApi.Models.Dtos;

namespace ProductsAttributesRestApi.Services
{
    public interface IAuthService
    {
        Task<List<UserResponse>> RegisterUser(UserRequest userRequest);
        Task<string> LoginUser(UserLoginRequest userLoginRequest);
    }
}
