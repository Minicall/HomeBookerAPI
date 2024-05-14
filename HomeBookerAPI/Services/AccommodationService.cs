using HomeBookerAPI.Data.Repositories;
using HomeBookerAPI.Models;

namespace HomeBookerAPI.Services
{
    public interface IAccommodationService
    {
        Task<IEnumerable<Accommodation>> GetAllAccommodationsAsync();
        Task<Accommodation> GetAccommodationByIdAsync(Guid id);
        Task<Accommodation> AddAccommodationAsync(Accommodation accommodation);
        Task<Accommodation> UpdateAccommodationAsync(Accommodation accommodation);
        Task DeleteAccommodationAsync(Guid id);
    }

    public class AccommodationService : IAccommodationService
    {
        private readonly IRepository<Accommodation> _accommodationRepository;

        public AccommodationService(IRepository<Accommodation> accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public async Task<IEnumerable<Accommodation>> GetAllAccommodationsAsync()
        {
            return await _accommodationRepository.GetAllAsync();
        }

        public async Task<Accommodation> GetAccommodationByIdAsync(Guid id)
        {
            return await _accommodationRepository.GetByIdAsync(id);
        }

        public async Task<Accommodation> AddAccommodationAsync(Accommodation accommodation)
        {
            return await _accommodationRepository.AddAsync(accommodation);
        }

        public async Task<Accommodation> UpdateAccommodationAsync(Accommodation accommodation)
        {
            return await _accommodationRepository.UpdateAsync(accommodation);
        }

        public async Task DeleteAccommodationAsync(Guid id)
        {
            await _accommodationRepository.DeleteAsync(id);
        }
    }
}
