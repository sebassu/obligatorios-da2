using System;

namespace Domain
{
    public enum LoggedActions { LOGIN, VEHICLE_IMPORT }

    public class LoggingRecord
    {
        public int Id { get; set; }

        private User responsible;
        public User Responsible
        {
            get { return responsible; }
            set
            {
                if (IsValidAdministrator(value))
                {
                    responsible = value;
                }
                else
                {
                    throw new LoggingRecordException(ErrorMessages.ResponsibleUserIsInvalid);
                }
            }
        }

        private bool IsValidAdministrator(User someUser)
        {
            return Utilities.IsNotNull(someUser)
                && someUser.Role == UserRoles.ADMINISTRATOR;
        }

        public LoggedActions ActionPerformed { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        internal static LoggingRecord InstanceForTestingPurposes()
        {
            return new LoggingRecord();
        }

        protected LoggingRecord() { }

        public static LoggingRecord FromResponsibleActionPerformed(User responsible,
            LoggedActions actionPerformed)
        {
            return new LoggingRecord(responsible, actionPerformed);
        }

        protected LoggingRecord(User responsibleToSet,
            LoggedActions actionPerformedToSet)
        {
            Responsible = responsibleToSet;
            ActionPerformed = actionPerformedToSet;
        }
    }
}