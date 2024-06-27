using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions;
using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Reservations.Domain.Model.Aggregates;

namespace ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Entities to be created */

            //user entity
            var userEntity = builder.Entity<User>();

            userEntity.ToTable("User");
            userEntity.HasKey(u => u.Id);
            userEntity.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            userEntity.Property(u => u.Email).IsRequired();
            userEntity.Property(u => u.Password).IsRequired();
            userEntity.OwnsOne(u => u.UserName, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
            userEntity.Property(u => u.Dni).IsRequired().HasMaxLength(8);
            userEntity.Property(u => u.Phone).IsRequired().HasMaxLength(9);
            userEntity.Property(u => u.DateOfBirth).IsRequired();
            
            //parking entity
            var parkingEntity = builder.Entity<Parking>();
            
            parkingEntity.ToTable("Parking");
            parkingEntity.HasKey(p => p.Id);
            parkingEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            parkingEntity.Property(p => p.Address).IsRequired();
            parkingEntity.Property(p => p.Width).IsRequired();
            parkingEntity.Property(p => p.Length).IsRequired();
            parkingEntity.Property(p => p.Height).IsRequired();
            parkingEntity.Property(p => p.Price).IsRequired();
            parkingEntity.Property(p => p.Phone).IsRequired();
            parkingEntity.Property(p => p.Description).IsRequired();
            parkingEntity.Property(p => p.UserId).IsRequired();

            //booking entity
            var bookingEntity = builder.Entity<Booking>();

            bookingEntity.ToTable("Booking");
            bookingEntity.HasKey(p => p.Id);
            bookingEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            bookingEntity.Property(p => p.HoursRegistered).IsRequired();
            bookingEntity.Property(p => p.TotalPrice).IsRequired();
            bookingEntity.Property(p => p.StartHour).IsRequired();
            bookingEntity.Property(p => p.EndHour).IsRequired();
            bookingEntity.Property(p => p.ParkingId).IsRequired();
            bookingEntity.Property(p => p.UserId).IsRequired();
            bookingEntity.Property(p => p.BookingStatus);
            
            //review entity
            var reviewEntity = builder.Entity<Review>();
            
            reviewEntity.ToTable("Review");
            reviewEntity.HasKey(r => r.Id);
            reviewEntity.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            reviewEntity.Property(r => r.Comment).IsRequired();
            reviewEntity.Property(r => r.Rating).IsRequired();
            reviewEntity.Property(r => r.ParkingId).IsRequired();
            reviewEntity.Property(r => r.UserId).IsRequired();
            

            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
