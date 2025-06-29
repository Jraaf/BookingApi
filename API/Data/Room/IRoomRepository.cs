using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Room;

public interface IRoomRepository
{
    Task<Room> Create(Room room);
    Task<IEnumerable<Room>> GetAll();
}
