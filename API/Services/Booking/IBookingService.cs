using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Booking;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAll();
    Task<BookingDto> Create(BookingDto booking);
    Task<bool> Delete(int id);
}
