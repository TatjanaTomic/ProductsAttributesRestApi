using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories;

public interface IUsersRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<List<User>> AddUser(User user);
}
