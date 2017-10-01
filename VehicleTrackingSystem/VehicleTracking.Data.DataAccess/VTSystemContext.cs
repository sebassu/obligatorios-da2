using Domain;
using System.Data.Entity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
    public class VTSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Zone> Zones { get; set; }

        public DbSet<Subzone> Subzones { get; set; }

        public VTSystemContext() : base()
        {
            var defaultInitializer = new DropCreateDatabaseIfModelChanges<VTSystemContext>();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.LazyLoadingEnabled = false;
        }

        internal void DeleteAllData()
        {
            Database.ExecuteSqlCommand("delete from users");
            Database.ExecuteSqlCommand("delete from vehicles");
            Database.ExecuteSqlCommand("delete from locations");
            Database.ExecuteSqlCommand("delete from subzones");
            Database.ExecuteSqlCommand("delete from zones");
        }
    }
}