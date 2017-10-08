using Domain;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<Damage> Damages { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public VTSystemContext() : base()
        {
            var defaultInitializer = new VTSystemDatabaseInitializer();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.LazyLoadingEnabled = false;
            VehicleEntityDatabaseSettings(modelBuilder);
            modelBuilder.Entity<Zone>().HasMany(z => z.Subzones)
                .WithRequired(s => s.Container);
            modelBuilder.Entity<Subzone>().HasMany(z => z.Vehicles)
                .WithOptional();
            LotEntityDatabaseSettings(modelBuilder);
            modelBuilder.Entity<Inspection>().HasMany(i => i.Damages).WithRequired()
                .WillCascadeOnDelete();
            modelBuilder.Entity<Transport>().HasMany(t => t.LotsTransported)
                .WithOptional(l => l.AssociatedTransport);
            ProcessDataDatabaseSettings(modelBuilder);
        }

        private static void VehicleEntityDatabaseSettings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().Ignore(v => v.PortLot);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.PortInspection);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.YardInspection);
            modelBuilder.Entity<Vehicle>().Ignore(v => v.CurrentStage);
            modelBuilder.Entity<Vehicle>().HasRequired(v => v.StagesData)
                .WithRequiredDependent().WillCascadeOnDelete();
        }

        private static void LotEntityDatabaseSettings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lot>().Property(l => l.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Lot>().HasMany(l => l.Vehicles).WithOptional();
            modelBuilder.Entity<Lot>().HasRequired(l => l.Creator).WithMany();
            modelBuilder.Entity<Lot>().Ignore(t => t.WasTransported);
        }

        private static void ProcessDataDatabaseSettings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessData>().HasOptional(p => p.PortInspection).WithRequired()
                .WillCascadeOnDelete();
            modelBuilder.Entity<ProcessData>().HasOptional(p => p.YardInspection).WithRequired()
                .WillCascadeOnDelete();
            modelBuilder.Entity<ProcessData>().HasMany(i => i.YardMovements).WithRequired()
                .WillCascadeOnDelete();
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