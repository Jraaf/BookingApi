using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Room;
using Data.User;
using Services.Room;
using Services.User;

namespace Services.Booking;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public RoomDto? Room { get; set; }
    public UserDto? Booker { get; set; }
}
