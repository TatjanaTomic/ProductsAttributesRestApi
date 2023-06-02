using Microsoft.EntityFrameworkCore;
using ProductsAttributesAPI.Data;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Repositories.Impl
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {

        public UsersRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<User> AddUser(User user)
        {
            var userEntity = await _dataContext.Users.AddAsync(user);
            _dataContext.SaveChanges();
            return userEntity.Entity;        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
