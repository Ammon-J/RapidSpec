using Microsoft.EntityFrameworkCore;
using RapidSpec.Models;

namespace RapidSpec.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected VehicleDbContext()
        {
        }


        public DbSet<Vehicle> VehicleSpecs { get; set; } = null!;
    }
}
