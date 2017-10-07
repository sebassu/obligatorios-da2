using Domain;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class LotDTO
    {
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> VehicleVINs { get; set; }

        internal LotDTO() { }

        internal static LotDTO FromLot(Lot someLot)
        {
            return new LotDTO(someLot);
        }

        protected LotDTO(Lot someLot) : this(someLot.Id,
            someLot.Name, someLot.Description)
        {
            SetVehiclesIds(someLot);
        }

        private void SetVehiclesIds(Lot someLot)
        {
            var vehiclesToSet = someLot.Vehicles;
            if (Utilities.IsNotNull(vehiclesToSet))
            {
                VehicleVINs = vehiclesToSet.Select(v => v.VIN).ToList();
            }
        }

        protected LotDTO(int idToSet, string nameToSet,
            string descriptionToSet)
        {
            Id = idToSet;
            Name = nameToSet;
            Description = descriptionToSet;
        }

        internal void SetDataToLot(Lot lotToModify, ICollection<Vehicle> list)
        {
            lotToModify.Name = Name;
            lotToModify.Description = Description;
            lotToModify.Vehicles = list;

        }

        internal Lot ToLot(User creator, ICollection<Vehicle> vehicles)
        {
            return Lot.CreatorNameDescriptionVehicles(creator, Name, Description, vehicles);
        }
    }
}