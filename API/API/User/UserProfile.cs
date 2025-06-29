using AutoMapper;
using Services.User;

namespace API.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserDto, UserDto>();
        CreateMap<LoginUserDto, UserDto>();
        CreateMap<Data.User.User, UserDto>().ReverseMap();
    }
}
