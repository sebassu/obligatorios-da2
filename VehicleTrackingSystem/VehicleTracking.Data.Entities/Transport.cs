using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleTracking_Data_Entities
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

        private bool IsValidTransportStartDate(DateTime? valueToSet)
        {
            bool isValidDate = valueToSet.HasValue && Utilities.IsValidDate(valueToSet.Value);
            return isValidDate && LotsTransported.All(l => l.Vehicles.All(
                v => v.PortInspection.DateTime <= valueToSet.GetValueOrDefault()));
        }

        public void FinalizeTransportOnDate(DateTime endTime)
        {
            EndDateTime = endTime;
            MarkTransportFinalizedOnLots();
        }

        private void MarkTransportFinalizedOnLots()
        {
            foreach (var lot in LotsTransported)
            {
                lot.FinalizeTransport();
            }
        }

        private DateTime? endDateTime;
        public DateTime? EndDateTime
        {
            get { return endDateTime; }
            set
            {
                bool canSetEndOfTransport = IsValidTransportEndDate(value);
                if (canSetEndOfTransport)
                {
                    endDateTime = value;
                }
                else
                {
                    throw new TransportException(ErrorMessages.TransportEndDateIsInvalid);
                }
            }
        }

        private bool IsValidTransportEndDate(DateTime? valueToSet)
        {
            bool isNull = !valueToSet.HasValue;
            return isNull ||
                (Utilities.IsValidDate(valueToSet.Value) && valueToSet.Value > startDateTime);
        }

        public ICollection<Lot> LotsTransported { get; set; }
            = new List<Lot>();

        internal static Transport InstanceForTestingPurposes()
        {
            return new Transport();
        }

        protected Transport() { }

        public static Transport FromTransporterDateTimeLots(User someTransporter,
            DateTime startTime, ICollection<Lot> lotsToSet)
        {
            return new Transport(someTransporter, startTime, lotsToSet);
        }

        public Transport(User someTransporter, DateTime startTime,
            ICollection<Lot> lotsToSet)
        {
            if (IsValidCollectionOfLots(lotsToSet))
            {
                SetCreationAttributes(someTransporter, startTime, lotsToSet);
                MarkLotsAsTransported();
            }
            else
            {
                throw new TransportException(ErrorMessages.InvalidLotsInTransport);
            }
        }

        private bool IsValidCollectionOfLots(ICollection<Lot> lotsToSet)
        {
            return Utilities.IsValidItemEnumeration(lotsToSet)
                && lotsToSet.All(l => (!l.WasTransported) && (l.IsReadyForTransport()));
        }

        private void SetCreationAttributes(User someTransporter,
            DateTime startTime, ICollection<Lot> lotsToSet)
        {
            Transporter = someTransporter;
            LotsTransported = lotsToSet;
            StartDateTime = startTime;
        }

        private void MarkLotsAsTransported()
        {
            foreach (var lot in LotsTransported)
            {
                lot.MarkAsTransported(this);
            }
        }
    }
}