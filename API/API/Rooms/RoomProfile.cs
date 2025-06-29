using AutoMapper;
using Services.Room;

namespace API.Room;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<CreateRoomDto, RoomDto>();
        CreateMap<RoomDto, OutputRoomDto>();
        CreateMap<RoomDto, Data.Room.Room>().ReverseMap();
    }
}
