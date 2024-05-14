using HomeBookerAPI.Data.Repositories;
using HomeBookerAPI.Models;

namespace HomeBookerAPI.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Guid id);
    }

    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.AddAsync(reservation);
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteReservationAsync(Guid id)
        {
            await _reservationRepository.DeleteAsync(id);
        }
    }
}
