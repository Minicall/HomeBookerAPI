using HomeBookerAPI.Models;
using HomeBookerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookerAPI.Controllers
{
    [Route("api/accommodation")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService _accommodationService;
        
        public AccommodationController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAllAccommodationsAsync()
        {
            var accommodation = await _accommodationService.GetAllAccommodationsAsync();

            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodationByIdAsync(Guid id)
        {
            var accommodation = await _accommodationService.GetAccommodationByIdAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodations(AccommodationRequest accommodationReguest)
        {
            Accommodation accommodation = new Accommodation()
            {
                Name = accommodationReguest.Name,
                Location = accommodationReguest.Location
            };

            await _accommodationService.AddAccommodationAsync(accommodation);
            return CreatedAtAction(nameof(GetAccommodationByIdAsync), new { id = accommodation.Id }, accommodation);
        }

        [HttpPut]
        public async Task<IActionResult> PutAccommodations([FromQuery] Guid id, AccommodationRequest accommodationRequest)
        {
            var accommodation = await _accommodationService.GetAccommodationByIdAsync(id);

            accommodation.Name = accommodationRequest.Name;
            accommodation.Location = accommodationRequest.Location;

            await _accommodationService.UpdateAccommodationAsync(accommodation);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccommodations([FromQuery] Guid id)
        {
            await _accommodationService.DeleteAccommodationAsync(id);

            return NoContent();
        }
    }
}
