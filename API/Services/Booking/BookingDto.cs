using Services.Room;

namespace Services.Booking;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public RoomDto? Room { get; set; }
    public string? BookerName { get; set; }
}
