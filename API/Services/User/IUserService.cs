using Data.User;

namespace Services.User;

public interface IUserService
{
    Task<bool> Register(UserDto user);
    Task<string> Login(UserDto user);
    string CreateToken(UserDto user);
}
