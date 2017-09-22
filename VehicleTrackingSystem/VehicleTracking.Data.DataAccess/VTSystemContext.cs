﻿using Domain;
using System.Data.Entity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
    public class VTSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public VTSystemContext() : base()
        {
            var defaultInitializer = new DropCreateDatabaseIfModelChanges<VTSystemContext>();
            Database.SetInitializer(defaultInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.Username);
            Configuration.LazyLoadingEnabled = false;
        }

        internal void DeleteAllData()
        {
            Database.ExecuteSqlCommand("delete from users");
            Database.ExecuteSqlCommand("delete from vehicles");
        }
    }
}