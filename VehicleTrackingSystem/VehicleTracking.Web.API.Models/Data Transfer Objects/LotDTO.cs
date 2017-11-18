using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    [Serializable]
    public class LotDTO
    {
        public string CreatorUsername { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<string> VehicleVINs { get; set; }

        public bool IsReadyForTransport { get; set; }

        internal LotDTO() { }

        internal static LotDTO FromLot(Lot someLot)
        {
            return new LotDTO(someLot);
        }

        private LotDTO(Lot someLot) : this(someLot.Name,
            someLot.Description, someLot.Creator.Username)
        {
            VehicleVINs = someLot.Vehicles.Select(v => v.VIN).ToList();
            IsReadyForTransport = someLot.IsReadyForTransport();
        }

        private LotDTO(string nameToSet, string descriptionToSet,
            string creatorUsernameToSet)
        {
            Name = nameToSet;
            Description = descriptionToSet;
            CreatorUsername = creatorUsernameToSet;
        }

        internal void SetDataToLot(Lot lotToModify,
            ICollection<Vehicle> list)
        {
            lotToModify.Name = Name;
            lotToModify.Description = Description;
            lotToModify.Vehicles = list;
        }

        internal Lot ToLot(User creator, ICollection<Vehicle> vehicles)
        {
            return Lot.CreatorNameDescriptionVehicles(creator, Name,
                Description, vehicles);
        }
    }
}