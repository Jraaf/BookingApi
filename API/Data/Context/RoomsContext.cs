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
    public DbSet<Room.Room> Rooms { get; set; }
    public DbSet<Booking.Booking> Bookings { get; set; }
    public DbSet<User.User> Users { get; set; }
}
