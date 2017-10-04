using System;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        void SaveChanges();
        void DeleteAllDataFromDatabase();
    }
}