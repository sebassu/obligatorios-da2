using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public class SubzoneDTO
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<int> VehicleIds { get; set; }

        internal SubzoneDTO() { }

        internal static SubzoneDTO FromSubzone(Subzone someSubzone)
        {
            return new SubzoneDTO(someSubzone);
        }

        protected SubzoneDTO(Subzone someSubzone) : this(someSubzone.Id,
            someSubzone.Name, someSubzone.Capacity)
        {
            SetVehiclesIds(someSubzone);
            SetContainerId(someSubzone);
        }

        private void SetVehiclesIds(Subzone someSubzone)
        {
            var vehiclesToSet = someSubzone.Vehicles;
            if (Utilities.IsNotNull(vehiclesToSet))
            {
                VehicleIds = vehiclesToSet.Select(v => v.Id).ToList();
            }
        }

        private void SetContainerId(Subzone someSubzone)
        {
            var containerToSet = someSubzone.Container;
            if (Utilities.IsNotNull(containerToSet))
            {
                ContainerId = containerToSet.Id;
            }
        }

        public static SubzoneDTO FromData(string nameToSet, int capacityToSet)
        {
            return new SubzoneDTO(0, nameToSet, capacityToSet);
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