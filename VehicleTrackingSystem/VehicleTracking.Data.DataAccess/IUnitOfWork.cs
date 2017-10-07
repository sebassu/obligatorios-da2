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
        ILocationRepository Locations { get; }
        void SaveChanges();
    }
}