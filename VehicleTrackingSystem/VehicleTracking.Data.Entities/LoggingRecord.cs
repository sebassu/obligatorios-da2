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

        private string elementIdentifier;
        public string ElementIdentifier
        {
            get { return elementIdentifier; }
            set
            {
                if (IsValidElementIdentifier(value))
                {
                    elementIdentifier = value;
                }
                else
                {
                    throw new LoggingRecordException(
                        ErrorMessages.LoggingElementIdentifierIsInvalid);
                }
            }
        }

        protected bool IsValidElementIdentifier(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value);
        }

        public DateTime DateTime { get; protected set; } = DateTime.Now;

        internal static LoggingRecord InstanceForTestingPurposes()
        {
            return new LoggingRecord()
            {
                elementIdentifier = "Registro de acción inválido."
            };
        }
    }
}