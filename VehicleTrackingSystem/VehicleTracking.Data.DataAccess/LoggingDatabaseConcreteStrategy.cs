using Domain;
using System.Collections.Generic;

namespace Persistence
{
    internal class LoggingDatabaseConcreteStrategy : GenericRepository<LoggingRecord>,
        ILoggingStrategy
    {
        public LoggingDatabaseConcreteStrategy(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<LoggingRecord> Log => GetElementsWith();

        public LoggingRecord RegisterUserLogin(User loggedUser)
        {
            LoggingRecord logRecordToAdd =
                LoggingRecord.FromResponsibleActionPerformed(loggedUser, LoggedActions.LOGIN);
            Add(logRecordToAdd);
            return logRecordToAdd;
        }

        public LoggingRecord RegisterVehicleImport(User responsible)
        {
            LoggingRecord logRecordToAdd =
                LoggingRecord.FromResponsibleActionPerformed(responsible,
                LoggedActions.VEHICLE_IMPORT);
            Add(logRecordToAdd);
            return logRecordToAdd;
        }
    }
}