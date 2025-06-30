namespace API.Booking;

public class CreateBookingDto
{
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public int RoomId { get; set; }
}
