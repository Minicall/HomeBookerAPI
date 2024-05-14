using HomeBookerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeBookerAPI.Data
{
    public class HomeBookerDbContext : DbContext
    {
        public HomeBookerDbContext( DbContextOptions<HomeBookerDbContext> options) : base(options)
        {
        }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<Accommodation>().HasKey(p => p.Id);
            modelBuilder.Entity<Reservation>().HasKey(p => p.Id);
        }
    }
}
