using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Room;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAll();
    Task<RoomDto> Create(RoomDto room);
}
