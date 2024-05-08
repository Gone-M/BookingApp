using Microsoft.EntityFrameworkCore;
using booking.Models;

namespace booking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<CreditCardFlight> CreditCardFlight { get; set; }
        public DbSet<CreditCardHotel> CreditCardHotel { get; set; }
    }
}
