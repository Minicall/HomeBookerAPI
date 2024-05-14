namespace HomeBookerAPI.Models
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
