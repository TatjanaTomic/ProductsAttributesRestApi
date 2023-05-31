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

        public async Task<List<User>> AddUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return await _dataContext.Users.ToListAsync();        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
