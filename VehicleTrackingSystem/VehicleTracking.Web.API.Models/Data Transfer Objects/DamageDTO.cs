using System;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    [Serializable]
    public class DamageDTO
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<string> Images { get; set; }

        internal DamageDTO() { }

        internal static DamageDTO FromDamage(Damage someDamage)
        {
            return new DamageDTO(someDamage);
        }

        private DamageDTO(Damage someDamage)
        {
            Description = someDamage.Description;
            Images = someDamage.Images;
        }

        internal Damage ToDamage()
        {
            return Damage.CreateNewDamage(Description, Images);
        }
    }
}