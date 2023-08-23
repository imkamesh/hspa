using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;

namespace PropertyAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            return  await dataContext.Users.FirstOrDefaultAsync(x => x.Username == username 
            && x.Password == password);
        }
    }
}
