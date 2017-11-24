using System;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
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
        ICustomerRepository Customers { get; }
        ISaleRepository Sales { get; }
        IFlowRepository Flow { get; }
        ILoggingStrategy LoggingStrategy { get; }
        void SaveChanges();
    }
}