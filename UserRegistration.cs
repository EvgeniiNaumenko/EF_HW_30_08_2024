using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_003_30_08_2024
{
    internal class UserRegistration
    {
        private readonly ApplicationContext _context;
        public UserRegistration(ApplicationContext context)
        {
            _context = context;
        }
        private bool RegisterUser (User user)
        {
            if(_context.Users.Any(u=>u.UserLogin==user.UserLogin))
            {
                Console.WriteLine("User is already registered!");
                return false;
            }
            string passwordHash = PasswordHash.HashPassword(user.PasswordHash);
            user.PasswordHash = passwordHash;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        public bool AuthenticateUser(User user)
        {
            string passwordHash = PasswordHash.HashPassword(user.PasswordHash);
            return _context.Users.Any(u=>u.UserLogin == user.UserLogin && u.PasswordHash == passwordHash);
        }
        public bool CreateUser()
        {
            string regUserLogin = Helper.GetString("User Login ");
            string regUserPassword = Helper.GetString("User Password ");
            User user = new User 
            { 
                UserLogin = regUserLogin,
                PasswordHash = regUserPassword
            };
            if (Helper.Check(user))
            {
                RegisterUser(user);
                return true;
            }
            return false;
        }
    }
}
