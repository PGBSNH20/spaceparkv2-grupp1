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

        public DbSet<SpacePort> SpacePorts { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpacePort>().HasData(
                new SpacePort { Id = 1, PortName = "Darth Port" },
                new SpacePort { Id = 2, PortName = "Port 2" });
            modelBuilder.Entity<Parking>().HasData(
                new Parking() { Id = 1, SpacePortId = 1, Fee = 10, MaxLength = 50, Occupied = false },
                new Parking() { Id = 2, SpacePortId = 1, Fee = 50, MaxLength = 100, Occupied = false },
                new Parking() { Id = 3, SpacePortId = 2, Fee = 100, MaxLength = 200, Occupied = false },
                new Parking() { Id = 4, SpacePortId = 2, Fee = 1000, MaxLength = 2000, Occupied = false },
                new Parking() { Id = 5, SpacePortId = 2, Fee = 5, MaxLength = 15, Occupied = false });
        }
    }
}
