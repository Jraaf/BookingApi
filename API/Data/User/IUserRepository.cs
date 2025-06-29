using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.User;

public interface IUserRepository
{
    Task<bool> Create(User user);
    Task<User?> GetByName(string username);
    Task<bool> Exists(string Username);
}
