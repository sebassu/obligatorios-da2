using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API.Services
{
    public class InspectionDTO
    {
        public int Id { get; set; }

        public string VehicleVIN { get; set; }

        [Required]
        public string LocationName { get; set; }

        public string ResponsibleUsername { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public ICollection<DamageDTO> Damages { get; set; }

        internal InspectionDTO() { }

        internal static InspectionDTO FromInspection(Inspection someInspection)
        {
            return new InspectionDTO(someInspection);
        }

        protected InspectionDTO(Inspection someInspection) :
            this(someInspection.Id, someInspection.VehicleVIN, someInspection.Location.Name,
                someInspection.ResponsibleUser.Username, someInspection.DateTime)
        {
            SetDamageDTOs(someInspection);
        }

        private void SetDamageDTOs(Inspection someInspection)
        {
            var damagesToSet = someInspection.Damages;
            if (Utilities.IsNotNull(damagesToSet))
            {
                Damages = damagesToSet.Select(d =>
                DamageDTO.FromDamage(d)).ToList();
            }
        }

        public InspectionDTO(int idToSet, string vinToSet, string locationNameToSet,
            string usernameToSet, DateTime dateTimeToSet)
        {
            Id = idToSet;
            VehicleVIN = vinToSet;
            LocationName = locationNameToSet;
            ResponsibleUsername = usernameToSet;
            DateTime = dateTimeToSet;
        }

        internal Inspection ToInspection(User responsible, Location locationToSet, Vehicle vehicleToSet)
        {
            return Inspection.CreateNewInspection(responsible, locationToSet, DateTime, GetDamages(), vehicleToSet);
        }

        internal ICollection<Damage> GetDamages()
        {
            return Damages.Select(d => d.ToDamage()).ToList();
        }
    }
}