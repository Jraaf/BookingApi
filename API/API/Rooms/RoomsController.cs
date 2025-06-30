using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Room;

namespace API.Room;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _service;
    private readonly IMapper _mapper;

    public RoomsController(IRoomService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _service.GetAll();

        return Ok(_mapper.Map<IEnumerable<OutputRoomDto>>(rooms));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateRoomDto room)
    {
        var createdRoom = await _service.Create(_mapper.Map<RoomDto>(room));
        if (createdRoom == null)
        {
            throw new Exception("Room creation failed");
        }
        return StatusCode(201, createdRoom);
    }
}
