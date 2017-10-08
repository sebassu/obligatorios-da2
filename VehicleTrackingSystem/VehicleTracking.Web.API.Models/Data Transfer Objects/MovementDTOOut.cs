using Domain;
using System;

namespace API.Services
{
    public class MovementDTOOut
    {
        public string ResponsibleUsername { get; set; }

        public string DepartureSubzone { get; set; }

        public string ArrivalSubzone { get; set; }

        public DateTime DateTime { get; set; }

        internal static MovementDTOOut FromMovement(Movement someMovement)
        {
            return new MovementDTOOut(someMovement);
        }

        public MovementDTOOut(Movement someMovement)
        {
            DateTime = someMovement.DateTime;
            DepartureSubzone = someMovement.Departure.ToString();
            ArrivalSubzone = someMovement.Arrival.ToString();
            ArrivalSubzone = someMovement.ResponsibleUser.Username;
        }
    }
}