using AutoMapper;
using Data.Room;

namespace Services.Room;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;
    private readonly IMapper _mapper;

    public RoomService(IRoomRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<RoomDto> Create(RoomDto room)
    {
        var roomDao = _mapper.Map<Data.Room.Room>(room);
        var createdRoom = await _repo.Create(roomDao);

        return _mapper.Map<RoomDto>(createdRoom);
    }

    public async Task<IEnumerable<RoomDto>> GetAll()
    {
        var rooms = await _repo.GetAll();

        return _mapper.Map<IEnumerable<RoomDto>>(rooms);
    }
}
