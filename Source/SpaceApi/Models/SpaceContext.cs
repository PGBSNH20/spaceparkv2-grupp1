using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaceApi.Models
{
    public class SpaceContext : DbContext
    {
        public SpaceContext(DbContextOptions<SpaceContext> options)
            : base(options)
        {
        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parking>().HasData(
                new Parking() { Id = 1, Fee = 10, MaxLength = 50, Occupied = false },
                new Parking() { Id = 2, Fee = 50, MaxLength = 100, Occupied = false },
                new Parking() { Id = 3, Fee = 100, MaxLength = 200, Occupied = false },
                new Parking() { Id = 4, Fee = 1000, MaxLength = 2000, Occupied = false },
                new Parking() { Id = 5, Fee = 5, MaxLength = 15, Occupied = false });
        }
    }
}
