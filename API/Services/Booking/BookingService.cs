using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Booking;

namespace Services.Booking;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repo;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<BookingDto> Create(BookingDto dto)
    {
        var booking = _mapper.Map<Data.Booking.Booking>(dto);

        if (! await _repo.IsAvailable(booking))
        {
            throw new InvalidOperationException("Room is not available for the selected time.");
        }

        var result = await _repo.Create(booking);
        
        return _mapper.Map<BookingDto>(result);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repo.Delete(id);
    }

    public async Task<IEnumerable<BookingDto>> GetAll()
    {
        return _mapper.Map<IEnumerable<BookingDto>>(await _repo.GetAll());
    }
}
