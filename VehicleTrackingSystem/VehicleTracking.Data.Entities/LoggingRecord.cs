using System;

namespace Domain
{
    public enum LoggedActions { USER_CREATION, VEHICLE_IMPORT }

    public class LoggingRecord
    {
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
                    throw new LoggingException(ErrorMessages.ResponsibleUserIsInvalid);
                }
            }
        }

        public LoggedActions ActionPerformed { get; internal set; }

        private bool IsValidAdministrator(User someUser)
        {
            return Utilities.IsNotNull(someUser)
                && someUser.Role == UserRoles.ADMINISTRATOR;
        }

        public string Identifier { get; internal set; }
        public DateTime DateTime { get; internal set; }
        
        internal static LoggingRecord InstanceForTestingPurposes()
        {
            return new LoggingRecord()
            {
                Identifier = "Registro de acción inválido."
            };
        }
    }
}