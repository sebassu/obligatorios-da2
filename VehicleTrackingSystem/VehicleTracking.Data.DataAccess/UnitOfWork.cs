﻿using Domain;
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

        private IInspectionRepository inspections;
        public IInspectionRepository Inspections
        {
            get
            {
                if (Utilities.IsNull(inspections))
                {
                    inspections = new InspectionRepository(context);
                }
                return inspections;
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

        private ILocationRepository locations;
        public ILocationRepository Locations
        {
            get
            {
                if (Utilities.IsNull(locations))
                {
                    locations = new LocationRepository(context);
                }
                return locations;
            }
        }

        private ILotRepository lots;
        public ILotRepository Lots
        {
            get
            {
                if (Utilities.IsNull(lots))
                {
                    lots = new LotRepository(context);
                }
                return lots;
            }
        }

        private IMovementRepository movements;
        public IMovementRepository Movements
        {
            get
            {
                if (Utilities.IsNull(movements))
                {
                    movements = new MovementRepository(context);
                }
                return movements;
            }
        }

        private ITransportRepository transports;
        public ITransportRepository Transports
        {
            get
            {
                if (Utilities.IsNull(transports))
                {
                    transports = new TransportRepository(context);
                }
                return transports;
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