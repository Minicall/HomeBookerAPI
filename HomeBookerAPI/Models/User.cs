using System.Transactions;

namespace HomeBookerAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
