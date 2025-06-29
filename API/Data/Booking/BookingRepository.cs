using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Booking;

public class BookingRepository : IBookingRepository
{
    private readonly RoomsContext _context;

    public BookingRepository(RoomsContext context)
    {
        _context = context;
    }
    public async Task<Booking> Create(Booking booking)
    {
        var data = _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return data.Entity;
    }

    public async Task<bool> Delete(int id)
    {
        return (await _context.Bookings
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync()) > 0;
    }

    public async Task<IEnumerable<Booking>> GetAll()
    {
        return await _context.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .ToListAsync();
    }
}
