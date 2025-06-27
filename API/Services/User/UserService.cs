using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.User;
using AutoMapper;
using Data.User;
using Services.Exceptions;

namespace Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public string CreateToken(UserDto user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Login(LoginUserDto dto)
    {
        var user = await _repo.GetByName(dto.Username);

        if (user == null)
        {
            throw new NotFoundException(dto.Username);
        }

        var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
                throw new Exception("Wrong password");
        }
        var endUser = new UserDto()
        {
            Id = user.Id,
            Username = user.Username,
            AccessToken = CreateToken(user),
        };
        return endUser;
    }

    public Task<UserDto> Register(RegisterUserDto user)
    {
        throw new NotImplementedException();
    }
}
