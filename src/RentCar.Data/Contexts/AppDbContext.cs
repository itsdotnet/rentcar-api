using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Provider> Providers { get; set;}
    public DbSet<Car> Cars { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Book> Booking { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
}
