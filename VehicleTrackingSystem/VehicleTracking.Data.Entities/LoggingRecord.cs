using System;

namespace Domain
{
    public enum LoggedActions { LOGIN, VEHICLE_IMPORT }

    public class LoggingRecord
    {
        public int Id { get; set; }

        public User Responsible { get; set; }

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
            if (IsValidUserForAction(responsibleToSet,
                actionPerformedToSet))
            {
                SetCreationAttributes(responsibleToSet, actionPerformedToSet);
            }
            else
            {
                throw new LoggingException(
                    ErrorMessages.InvalidUserRoleForLogging);
            }
        }

        private bool IsValidUserForAction(User someUser,
            LoggedActions actionPerformed)
        {
            bool isNotNull = Utilities.IsNotNull(someUser);
            return isNotNull && (actionPerformed == LoggedActions.VEHICLE_IMPORT ?
                someUser.Role == UserRoles.ADMINISTRATOR : true);
        }

        private void SetCreationAttributes(User responsibleToSet,
            LoggedActions actionPerformedToSet)
        {
            Responsible = responsibleToSet;
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