using Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public class SubzoneDTO
    {
        public int Id { get; set; }

        public int ContainerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<string> VehicleVINs { get; set; }

        internal SubzoneDTO() { }

        internal static SubzoneDTO FromSubzone(Subzone someSubzone)
        {
            return new SubzoneDTO(someSubzone);
        }

        protected SubzoneDTO(Subzone someSubzone) : this(someSubzone.Id,
            someSubzone.Name, someSubzone.Capacity)
        {
            SetVehiclesIds(someSubzone);
            ContainerId = someSubzone.Container.Id;
        }

        private void SetVehiclesIds(Subzone someSubzone)
        {
            var vehiclesToSet = someSubzone.Vehicles;
            if (Utilities.IsNotNull(vehiclesToSet))
            {
                VehicleVINs = vehiclesToSet.Select(v => v.VIN).ToList();
            }
        }

        protected SubzoneDTO(int idToSet, string nameToSet,
            int capacityToSet)
        {
            Id = idToSet;
            Name = nameToSet;
            Capacity = capacityToSet;
        }

        internal Subzone ToSubzone(Zone container)
        {
            return Subzone.CreateNewSubzone(Name, Capacity, container);
        }

        internal void SetDataToSubzone(Subzone subzoneToModify)
        {
            subzoneToModify.Name = Name;
            subzoneToModify.Capacity = Capacity;
        }

        public override bool Equals(object obj)
        {
            SubzoneDTO dtoToCompareAgainst = obj as SubzoneDTO;
            if (Utilities.IsNotNull(dtoToCompareAgainst))
            {
                return Id.Equals(dtoToCompareAgainst.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}