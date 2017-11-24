using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    [Serializable]
    public class ZoneDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<int> SubzoneIds { get; set; }

        public ZoneDTO() { }

        internal static ZoneDTO FromZone(Zone someZone)
        {
            return new ZoneDTO(someZone);
        }

        private ZoneDTO(Zone someZone) : this(someZone.Name,
            someZone.Capacity)
        {
            var subzonesToSet = someZone.Subzones;
            if (Utilities.IsNotNull(subzonesToSet))
            {
                SubzoneIds = subzonesToSet.Select(s => s.Id).ToList();
            }
        }

        internal static ZoneDTO FromData(string name, int capacity,
            ICollection<int> subzoneIds = null)
        {
            return new ZoneDTO(name, capacity)
            {
                SubzoneIds = subzoneIds
            };
        }

        private ZoneDTO(string nameToSet, int capacityToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
        }

        internal Zone ToZone()
        {
            return Zone.CreateNewZone(Name, Capacity);
        }

        internal void SetDataToZone(Zone zoneToModify)
        {
            zoneToModify.Name = Name;
            zoneToModify.Capacity = Capacity;
        }

        public override bool Equals(object obj)
        {
            ZoneDTO dtoToCompareAgainst = obj as ZoneDTO;
            if (Utilities.IsNotNull(dtoToCompareAgainst))
            {
                return Name.Equals(dtoToCompareAgainst.Name);
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