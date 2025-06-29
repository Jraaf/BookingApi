using Services.Room;

namespace API.Booking;

public class OutputRoomDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public RoomDto Room { get; set; }
    public string BookerName { get; set; }
}
