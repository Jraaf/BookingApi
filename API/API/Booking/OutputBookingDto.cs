using API.Room;
using Services.Room;

namespace API.Booking;

public class OutputBookingDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public OutputRoomDto Room { get; set; }
    public string BookerName { get; set; }
}
