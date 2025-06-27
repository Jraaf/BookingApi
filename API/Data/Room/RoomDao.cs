using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Booking;

namespace Data.Room;

public class RoomDao
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public ICollection<BookingDao> Bookings { get; set; }
}
