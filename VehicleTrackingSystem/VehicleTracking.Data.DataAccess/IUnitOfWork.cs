using System;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        IZoneRepository Zones { get; }
        void SaveChanges();
        void DeleteAllDataFromDatabase();
    }
}