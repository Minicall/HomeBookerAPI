namespace HomeBookerAPI.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AccommodationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public User User { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}
