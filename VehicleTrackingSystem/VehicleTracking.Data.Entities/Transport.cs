using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Transport
    {
        private static readonly IReadOnlyCollection<UserRoles> transportAllowedRoles =
            new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.TRANSPORTER }.AsReadOnly();

        public int Id { get; set; }

        private User transporter;
        public User Transporter
        {
            get { return transporter; }
            set
            {
                if (IsValidTransporter(value))
                {
                    transporter = value;
                }
                else
                {
                    throw new TransportException(ErrorMessages.TransportUserTypeIsInvalid);
                }
            }
        }

        private bool IsValidTransporter(User someTransporter)
        {
            return Utilities.IsNotNull(someTransporter) &&
                transportAllowedRoles.Contains(someTransporter.Role);
        }

        private DateTime? startDateTime;
        public DateTime? StartDateTime
        {
            get { return startDateTime; }
            set
            {
                if (IsValidTransportStartDate(value))
                {
                    startDateTime = value;
                }
                else
                {
                    throw new TransportException(ErrorMessages.TransportStartDateIsInvalid);
                }
            }
        }

        private bool IsValidTransportStartDate(DateTime? value)
        {
            return value.HasValue && LotsTransported.All(l => l.Vehicles.All(
                v => v.PortInspection.DateTime <= value.GetValueOrDefault()));
        }

        private DateTime? endDateTime;
        public DateTime? EndDateTime
        {
            get { return endDateTime; }
            set
            {
                bool canSetEndOfTransport = startDateTime.HasValue &&
                    IsValidTransportEndDate(value);
                if (canSetEndOfTransport)
                {
                    endDateTime = value.GetValueOrDefault();
                }
                else
                {
                    throw new TransportException(ErrorMessages.TransportEndDateIsInvalid);
                }
            }
        }

        private bool IsValidTransportEndDate(DateTime? value)
        {
            return value.HasValue && value.GetValueOrDefault() >= startDateTime;
        }

        public ICollection<Lot> LotsTransported { get; set; }
            = new List<Lot>();

        internal static Transport InstanceForTestingPurposes()
        {
            return new Transport()
            {
                transporter = User.InstanceForTestingPurposes()
            };
        }

        protected Transport() { }
    }
}
