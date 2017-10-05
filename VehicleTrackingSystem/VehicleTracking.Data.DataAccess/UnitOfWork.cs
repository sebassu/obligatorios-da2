using Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private VTSystemContext context = new VTSystemContext();

        private IUserRepository users;
        public IUserRepository Users
        {
            get
            {
                if (Utilities.IsNull(users))
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        private IVehicleRepository vehicles;
        public IVehicleRepository Vehicles
        {
            get
            {
                if (Utilities.IsNull(vehicles))
                {
                    vehicles = new VehicleRepository(context);
                }
                return vehicles;
            }
        }

        private IZoneRepository zones;
        public IZoneRepository Zones
        {
            get
            {
                if (Utilities.IsNull(zones))
                {
                    zones = new ZoneRepository(context);
                }
                return zones;
            }
        }

        private ISubzoneRepository subzones;
        public ISubzoneRepository Subzones
        {
            get
            {
                if (Utilities.IsNull(subzones))
                {
                    subzones = new SubzoneRepository(context);
                }
                return subzones;
            }
        }

        public void DeleteAllDataFromDatabase()
        {
            context.DeleteAllDataFromDatabase();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        [ExcludeFromCodeCoverage]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}