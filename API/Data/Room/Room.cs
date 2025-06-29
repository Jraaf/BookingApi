using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Booking;

namespace Data.Room;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public ICollection<Booking.Booking> Bookings { get; set; }
}
