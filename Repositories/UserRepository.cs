using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Data;
using Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular.Repositories
{

     public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public  async Task<User> Login(UserLoginDto user)
        {
            var theUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (user == null) 
            {
                    return null;
            }
            var passwordIsMatch =  BCrypt.Net.BCrypt.Verify(user.Password , theUser.Password );
            if (passwordIsMatch) 
            {
                return theUser;
            } 
            return null;

        }

        public async Task<User> Register(User user)
        {
                var thePassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = thePassword ;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
        }

    

        public void Save()
        {
           _context.SaveChangesAsync();
        }

        public async Task<bool> UserExist(string username)
        {
            var foundUser = await _context.Users.AnyAsync(user => user.Username == username);
        
            if (foundUser)
            return true;
            return false;
        }
    }

    public interface IUserRepository 
    {
        void Save();
        Task<User> Login(UserLoginDto user);
        Task<User> Register(User user);
        Task<bool> UserExist(string username);
        
    }
    
}