using HotelManagement.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HotelManagement.Data;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole,string>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    //Hotel entities
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomAvailability> RoomAvailabilities { get; set; }

    // RefreshToken
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<UserRefreshToken>()
        .HasKey(urt => urt.Id); // Birincil anahtar tanımlaması

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }


}
