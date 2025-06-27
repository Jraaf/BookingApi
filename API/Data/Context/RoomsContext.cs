using Data.Booking;
using Data.Room;
using Data.User;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class RoomsContext : DbContext
{
    public RoomsContext(DbContextOptions<RoomsContext> options) : base(options)
    {
    }
    public DbSet<RoomDao> Rooms { get; set; }
    public DbSet<BookingDao> Bookings { get; set; }
    public DbSet<UserDao> Users { get; set; }
}
