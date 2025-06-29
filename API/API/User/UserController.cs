using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.User;

namespace API.User;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<ActionResult<OutputUserDto>> Register(RegisterUserDto user)
    {
        var userDto = _mapper.Map<UserDto>(user);
        if (await _service.Register(userDto))
        {
            var outputUser = new OutputUserDto
            {
                Username = userDto.Username,
                AccessToken = _service.CreateToken(userDto)
            };
            return Ok(outputUser);
        }
        return BadRequest("User already exists or registration failed");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto user)
    {
        var userDto = _mapper.Map<UserDto>(user);
        var result = await _service.Login(userDto);
        if (result == null) return Unauthorized("Invalid credentials");
        return Ok(result);
    }
}
