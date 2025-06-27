using Data.Room;
using Data.User;

namespace Data.Booking;

public class BookingDao
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public RoomDao Room { get; set; }
    public UserDao User { get; set; }
}
