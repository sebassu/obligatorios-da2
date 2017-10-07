using Domain;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace API.Services
{
    public class DamageDTO
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<string> Images { get; set; }

        internal static DamageDTO FromDamage(Damage someDamage)
        {
            return new DamageDTO(someDamage);
        }

        public DamageDTO(Damage someDamage)
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