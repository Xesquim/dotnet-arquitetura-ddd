using System;
using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<SiEntity>(new SiMap().Configure);
            modelBuilder.Entity<CityEntity>(new CityMap().Configure);
            modelBuilder.Entity<ZipCodeEntity>(new ZipCodeMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@test.com",
                    UserName = "admin",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Password = BCrypt.Net.BCrypt.HashPassword("password")
                }
            );

            SiSeeds.Sis(modelBuilder);
        }

    }
}
