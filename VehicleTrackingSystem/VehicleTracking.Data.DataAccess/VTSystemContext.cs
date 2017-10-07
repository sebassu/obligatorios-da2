using Domain;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
    [ExcludeFromCodeCoverage]
    public class VTSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ProcessData> ProcessDatas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Subzone> Subzones { get; set; }
        public DbSet<Lot> Lots { get; set; }

        public VTSystemContext() : base()
        {
            var defaultInitializer = new VTSystemDatabaseInitializer();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Entity<Vehicle>().Ignore(v => v.PortLot);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.PortInspection);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.YardInspection);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.CurrentStage);
            modelBuilder.Entity<Zone>().HasMany(z => z.Subzones)
                .WithRequired(s => s.Container);
            modelBuilder.Entity<Subzone>().HasMany(z => z.Vehicles)
                .WithOptional();
            modelBuilder.Entity<Lot>().HasMany(z => z.Vehicles).WithOptional();
            modelBuilder.Entity<Vehicle>().HasRequired(v => v.CurrentState)
                .WithRequiredPrincipal();
        }

        internal void DeleteAllDataFromDatabase()
        {
            Database.ExecuteSqlCommand("delete from processDatas");
            Database.ExecuteSqlCommand("delete from users");
            Database.ExecuteSqlCommand("delete from locations");
            Database.ExecuteSqlCommand("delete from movements");
            Database.ExecuteSqlCommand("delete from subzones");
            Database.ExecuteSqlCommand("delete from zones");
            Database.ExecuteSqlCommand("delete from vehicles");
            Database.ExecuteSqlCommand("delete from lots");
        }
    }
}