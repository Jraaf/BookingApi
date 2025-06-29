using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Room;

public class RoomRepository : IRoomRepository
{
    private readonly RoomsContext _context;

    public RoomRepository(RoomsContext context)
    {
        _context = context;
    }
    public async Task<Room> Create(Room room)
    {
        var result = _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        return await _context.Rooms.ToListAsync();
    }
}
