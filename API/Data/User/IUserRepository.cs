using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.User;

public interface IUserRepository
{
    Task<bool> Create(UserDao user);
    Task<UserDao> GetByName(string username);
    Task<bool> Exists(string Username);
}
