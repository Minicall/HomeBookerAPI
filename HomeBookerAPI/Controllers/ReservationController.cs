using HomeBookerAPI.Models;
using HomeBookerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookerAPI.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservationsAsync()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();

            if (reservations == null)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationByIdAsync(Guid id)
        {
            var reservations = await _reservationService.GetReservationByIdAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservations(ReservationRequest reservationReguest)
        {
            Reservation reservation = new Reservation()
            {
                UserId = reservationReguest.UserId,
                AccommodationId = reservationReguest.AccommodationId,
                CheckInDate = reservationReguest.CheckInDate,
                CheckOutDate = reservationReguest.CheckOutDate
            };

            await _reservationService.AddReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservationByIdAsync), new { id = reservation.Id }, reservation);
        }

        [HttpPut]
        public async Task<IActionResult> PutReservations([FromQuery] Guid id, ReservationRequest reservationRequest)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            reservation.CheckInDate = reservationRequest.CheckInDate;
            reservation.CheckOutDate = reservationRequest.CheckOutDate;

            await _reservationService.UpdateReservationAsync(reservation);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservations([FromQuery] Guid id)
        {
            await _reservationService.DeleteReservationAsync(id);

            return NoContent();
        }
    }
}
