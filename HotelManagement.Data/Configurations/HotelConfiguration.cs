using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManagement.Core.Entity;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(h => h.Address)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(h => h.Description)
               .HasMaxLength(500);

        builder.Property(h => h.StarRating)
               .IsRequired();

        // Entity-Framework'ün convention based yaklaşımından dolayı bunu confige dahil etmemize gerek yok.

        //builder.HasMany(h => h.Rooms)
        //       .WithOne(r => r.Hotel)
        //       .HasForeignKey(r => r.HotelId);

        // Örnek bir index ekleme
        builder.HasIndex(h => h.Name);
    }
}