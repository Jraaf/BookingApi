using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Booking;
using Services.Booking;

namespace API.Booking;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<CreateBookingDto, BookingDto>();

        CreateMap<BookingDto, Data.Booking.Booking>();

        CreateMap<Data.Booking.Booking, BookingDto>()
            .ForMember(dest => dest.BookerName, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));

        CreateMap<BookingDto, OutputBookingDto>()
            .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
    }
}
