using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Data;
using TaskManager.Core.Exceptions.UserExceptions;
using TaskManager.Core.Helper;
using TaskManager.Core.Models;
using TaskManager.Core.Service.Interface;

namespace TaskManager.Core.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserEntity?> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(u =>
                    u.UserName.ToLower() == username.ToLower());
                if (user == null || !PasswordHelper.VerifyPassword(password, user.PasswordHash))
                {
                    throw new UserAuthenticationException("Λάθος όνομα χρήστη ή κωδικός.");
                }
                return user;
            }
            catch (UserAuthenticationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserAuthenticationException("Αποτυχία ταυτοποίησης χρήστη.", ex);
            }

        }

        public async Task<UserEntity> RegisterAsync(string username, string password)
        {
            try
            {
                bool exists = await _appDbContext.Users.AnyAsync(u => u.UserName.ToLower() == username.ToLower());

                if (exists)
                {
                    throw new UserRegistrationException("Ο χρήστης υπάρχει ήδη.");
                }

                var user = new UserEntity
                {
                    UserName = username,
                    PasswordHash = PasswordHelper.HashPassword(password)
                };

                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();

                return user;
            }
            catch (UserRegistrationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserRegistrationException("Αποτυχία εγγραφής χρήστη.", ex);
            }

        }
    }
}
