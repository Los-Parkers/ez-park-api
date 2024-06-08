using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions;
using ez_park_platform.EzPark.Application.Domain.Model.Aggregates;

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

            builder.Entity<UserSource>().ToTable("UserSource");
            builder.Entity<UserSource>().HasKey(f => f.Id);
            builder.Entity<UserSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserSource>().Property(f => f.ApiKey).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserSource>().Property(f => f.SourceId).IsRequired().ValueGeneratedOnAdd();

            builder.UseSnakeCaseNamingConvention();
        }
    }
}
