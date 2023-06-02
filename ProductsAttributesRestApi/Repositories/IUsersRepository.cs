using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories;

public interface IUsersRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User> AddUser(User user);
}
