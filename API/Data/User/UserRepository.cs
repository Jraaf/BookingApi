using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.User;

public class UserRepository : IUserRepository
{
    public Task<bool> Create(UserDao user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(string Username)
    {
        throw new NotImplementedException();
    }

    public Task<UserDao> GetByName(string username)
    {
        throw new NotImplementedException();
    }
}
