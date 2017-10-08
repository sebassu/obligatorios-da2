using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class MovementDTOOut
    {
        public string ResponsibleUsername { get; set; }

        public string DepartureSubzone { get; set; }

        public string ArrivalSubzone { get; set; }

        public DateTime DateTime { get; set; }

        internal static ICollection<MovementDTOOut> FromMovements(
            ICollection<Movement> movements)
        {
            return movements.Select(m => FromMovement(m)).ToList();
        }

        internal static MovementDTOOut FromMovement(Movement someMovement)
        {
            return new MovementDTOOut(someMovement);
        }

        private MovementDTOOut(Movement someMovement)
        {
            var departure = someMovement.Departure;
            DateTime = someMovement.DateTime;
            DepartureSubzone = Utilities.IsNull(departure) ? "Patio"
                : departure.ToString();
            ArrivalSubzone = someMovement.Arrival.ToString();
            ResponsibleUsername = someMovement.ResponsibleUser.Username;
        }
    }
}