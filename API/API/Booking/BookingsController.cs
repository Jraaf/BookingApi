using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Booking;

namespace API.Booking;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;
    private readonly IMapper _mapper;

    public BookingsController(IBookingService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _service.GetAll();
        return Ok(_mapper.Map<IEnumerable<OutputBookingDto>>(bookings));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto bookingDto)
    {
        if (bookingDto == null)
        {
            return BadRequest("Booking data is required.");
        }
        var booking = _mapper.Map<BookingDto>(bookingDto);
        booking.UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

        var createdBooking = await _service.Create(booking);

        return StatusCode(201, _mapper.Map<OutputBookingDto>(createdBooking));
    }
}
