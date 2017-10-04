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
