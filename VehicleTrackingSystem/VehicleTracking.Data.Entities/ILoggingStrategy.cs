using System.Collections.Generic;

namespace VehicleTracking_Data_Entities
{
    public interface ILoggingStrategy
    {
        IEnumerable<LoggingRecord> Log { get; }
        LoggingRecord RegisterUserLogin(User loggedUser);
        LoggingRecord RegisterVehicleImport(User responsible);
    }
}
