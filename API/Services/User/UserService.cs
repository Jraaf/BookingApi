using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Data.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;

namespace Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public UserService(IUserRepository repo, IMapper mapper, IConfiguration config)
    {
        _repo = repo;
        _mapper = mapper;
        _config = config;
    }

    public string CreateToken(UserDto user)
    {
        var tokenKey = _config["TokenKey"] ?? throw new Exception("Cannot access token key");
        if (tokenKey.Length < 64) throw new Exception("Too short key");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Username)
        };

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public async Task<string> Login(UserDto dto)
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
                throw new  Exception("Invalid credentials");
        }

        return CreateToken(dto);
    }

    public async Task<bool> Register(UserDto dto)
    {
        var user = await _repo.GetByName(dto.Username);

        if (user != null)
        {
            throw new UserExistsException(dto.Username);
        }
        using var hmac = new HMACSHA512();

        var userDao = new Data.User.User()
        {
            Username = dto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
            PasswordSalt = hmac.Key
        };        

        return await _repo.Create(userDao);
    }
}
