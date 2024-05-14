namespace HomeBookerAPI.Models
{
    public class ReservationRequest
    {
        public Guid UserId { get; set; }
        public Guid AccommodationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
