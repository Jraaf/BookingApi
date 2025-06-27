using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.User;

namespace Services.User;

public interface IUserService
{
    Task<UserDto> Register(RegisterUserDto user);
    Task<UserDto> Login(LoginUserDto user);
    string CreateToken(UserDto user);
}
