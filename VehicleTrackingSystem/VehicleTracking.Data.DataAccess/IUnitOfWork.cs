using Domain;
using System;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        IZoneRepository Zones { get; }
        IInspectionRepository Inspections { get; }
        ISubzoneRepository Subzones { get; }
        ILotRepository Lots { get; }
        ILocationRepository Locations { get; }
        IMovementRepository Movements { get; }
        ITransportRepository Transports { get; }
        ILoggingStrategy LoggingStrategy { get; }
        void SaveChanges();
    }
}