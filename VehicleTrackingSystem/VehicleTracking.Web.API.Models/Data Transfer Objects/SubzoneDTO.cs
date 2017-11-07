using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public class SubzoneDTO
    {
        public int Id { get; set; }

        public string ContainerName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<string> VehicleVINs { get; set; }

        public SubzoneDTO() { }

        internal static SubzoneDTO FromSubzone(Subzone someSubzone)
        {
            return new SubzoneDTO(someSubzone);
        }

        private SubzoneDTO(Subzone someSubzone) : this(someSubzone.Name,
            someSubzone.Capacity)
        {
            Id = someSubzone.Id;
            SetVehiclesIds(someSubzone);
            ContainerName = someSubzone.Container.Name;
        }

        private void SetVehiclesIds(Subzone someSubzone)
        {
            var vehiclesToSet = someSubzone.Vehicles;
            if (Utilities.IsNotNull(vehiclesToSet))
            {
                VehicleVINs = vehiclesToSet.Select(v => v.VIN).ToList();
            }
        }

        internal static SubzoneDTO FromData(string name, int capacity)
        {
            return new SubzoneDTO(name, capacity);
        }

        private SubzoneDTO(string nameToSet, int capacityToSet)
        {
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