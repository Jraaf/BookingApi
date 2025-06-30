using Data.Room;
using Data.User;

namespace Data.Booking;

public class Booking
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public Room.Room Room { get; set; }
    public User.User User { get; set; }
}
