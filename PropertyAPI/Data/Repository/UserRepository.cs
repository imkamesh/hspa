using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace PropertyAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public async Task<User> Authenticate(string username, string passwordText)
        {
            var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if(user == null || user.PasswordKey == null)
            {
                return null;
            }
            if(!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
            {
                return null;
            }
            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {                
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void Register(string username, string password)
        {
            byte[] passwordHash, passwordKey;
            using(var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            User user = new User();
            user.Username = username;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;

            dataContext.Users.Add(user);
        }

        public async Task<bool> UserAlreadyExists(string username)
        {
            return await dataContext.Users.AnyAsync(x => x.Username == username);
        }
    }
}
