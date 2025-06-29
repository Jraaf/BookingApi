using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Booking;

public interface IBookingRepository
{
    Task<Booking> Create(Booking booking);
    Task<IEnumerable<Booking>> GetAll();
    Task<bool> Delete(int id);
}
