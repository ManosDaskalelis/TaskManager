using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models;

namespace TaskManager.Core.Service.Interface
{
    public interface IUserService
    {
        Task<UserEntity?> AuthenticateAsync(string username, string password);
        Task<UserEntity> RegisterAsync(string username, string password);
    }
}
