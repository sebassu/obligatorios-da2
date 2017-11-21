using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    [Serializable]
    public class InspectionDTO
    {
        public string Id { get; set; }

        public string VehicleVIN { get; set; }

        [Required]
        public string LocationName { get; set; }

        public string ResponsiblesUsername { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public ICollection<DamageDTO> Damages { get; set; }

        internal InspectionDTO() { }

        internal static InspectionDTO FromInspection(Inspection someInspection)
        {
            return new InspectionDTO(someInspection);
        }

        private InspectionDTO(Inspection someInspection) :
            this(someInspection.Id, someInspection.VehicleVIN, someInspection.Location.Name,
                someInspection.Responsible.Username, someInspection.DateTime)
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

        private InspectionDTO(Guid idToSet, string vinToSet, string locationNameToSet,
            string usernameToSet, DateTime dateTimeToSet)
        {
            Id = idToSet.ToString();
            VehicleVIN = vinToSet;
            LocationName = locationNameToSet;
            ResponsiblesUsername = usernameToSet;
            DateTime = dateTimeToSet;
        }

        internal Inspection ToInspection(User responsible, Location locationToSet, Vehicle vehicleToSet)
        {
            var result = Inspection.CreateNewInspection(responsible, locationToSet, DateTime,
                GetDamages(), vehicleToSet);
            Id = result.Id.ToString();
            return result;
        }

        internal ICollection<Damage> GetDamages()
        {
            return Damages.Select(d => d.ToDamage()).ToList();
        }
    }
}