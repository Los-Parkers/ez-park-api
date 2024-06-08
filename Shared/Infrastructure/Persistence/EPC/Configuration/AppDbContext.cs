﻿using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions;
using ez_park_platform.Users.Domain.Model.Aggregates;

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


            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
