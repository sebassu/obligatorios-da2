using System;
using System.Globalization;

namespace VehicleTracking_Data_Entities
{
    public enum LoggedActions { LOGIN, VEHICLE_IMPORT }

    public class LoggingRecord
    {
        public int Id { get; set; }

        private string responsiblesUsername;
        public string ResponsiblesUsername
        {
            get { return responsiblesUsername; }
            set
            {
                if (User.IsValidUsername(value))
                {
                    responsiblesUsername = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.UsernameIsInvalid, value);
                    throw new LoggingException(errorMessage);
                }
            }
        }

        public LoggedActions ActionPerformed { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        internal static LoggingRecord InstanceForTestingPurposes()
        {
            return new LoggingRecord();
        }

        protected LoggingRecord() { }

        public static LoggingRecord FromUsernameAction(
            string responsiblesUsername, LoggedActions actionPerformed)
        {
            return new LoggingRecord(responsiblesUsername,
                actionPerformed);
        }

        protected LoggingRecord(string usernameToSet,
            LoggedActions actionPerformedToSet)
        {
            ResponsiblesUsername = usernameToSet;
            ActionPerformed = actionPerformedToSet;
        }

        public override bool Equals(object obj)
        {
            LoggingRecord recordToCompareAgainst = obj as LoggingRecord;
            if (Utilities.IsNotNull(recordToCompareAgainst))
            {
                return Id.Equals(recordToCompareAgainst.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}