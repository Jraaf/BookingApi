using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Room;

namespace API.Room;

[Authorize]
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
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _service.GetAll();

        return Ok(_mapper.Map<IEnumerable<OutputRoomDto>>(rooms));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoomDto room)
    {
        var createdRoom = await _service.Create(room);
        if (createdRoom == null)
        {
            throw new Exception("Room creation failed");
        }
        return StatusCode(201, createdRoom);
    }
}
