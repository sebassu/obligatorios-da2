using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class LoggingDatabaseConcreteStrategy : GenericRepository<LoggingRecord>,
        ILoggingStrategy
    {
        public LoggingDatabaseConcreteStrategy(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<LoggingRecord> Log => GetElementsWith();

        public LoggingRecord RegisterUserLogin(User loggedUser)
        {
            if (Utilities.IsNotNull(loggedUser))
            {
                return CreateNewLogRecordWithData(loggedUser, LoggedActions.LOGIN);
            }
            else
            {
                throw new LoggingException(ErrorMessages.NullObjectRecieved);
            }
        }

        public LoggingRecord RegisterVehicleImport(User responsible)
        {
            bool isValidUser = Utilities.IsNotNull(responsible)
                && responsible.Role == UserRoles.ADMINISTRATOR;
            if (isValidUser)
            {
                return CreateNewLogRecordWithData(responsible, LoggedActions.VEHICLE_IMPORT);
            }
            else
            {
                throw new LoggingException(ErrorMessages.InvalidUserRoleForLogging);
            }
        }

        private LoggingRecord CreateNewLogRecordWithData(User responsible, LoggedActions actionToLog)
        {
            LoggingRecord logRecordToAdd = LoggingRecord.FromUsernameAction(
                responsible.Username, actionToLog);
            Add(logRecordToAdd);
            return logRecordToAdd;
        }
    }
}