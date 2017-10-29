using System.Collections.Generic;

namespace Domain
{
    public interface ILoggingStrategy
    {
        IEnumerable<LoggingRecord> Log { get; }
        LoggingRecord RegisterUserLogin(User loggedUser);
        LoggingRecord RegisterVehicleImport(User responsible);
    }
}
