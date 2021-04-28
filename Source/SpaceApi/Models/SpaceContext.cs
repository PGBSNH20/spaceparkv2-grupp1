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
    }
}
