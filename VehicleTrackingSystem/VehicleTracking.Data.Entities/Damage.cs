using System.Collections.Generic;
using System.Globalization;

namespace Domain
{
    public class Damage
    {
        public int Id { get; set; }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (IsValidDescription(value))
                {
                    description = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.DescriptionIsInvalid, value);
                    throw new DamageException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidDescription(string value)
        {
            return Utilities.IsNotEmpty(value);
        }

        private ICollection<string> images;
        public ICollection<string> Images
        {
            get { return images; }
            set
            {
                if (Utilities.IsValidItemEnumeration(value))
                {
                    images = value;
                }
                else
                {
                    throw new DamageException(ErrorMessages.CollectionIsInvalid);
                }
            }
        }

        internal static Damage InstanceForTestingPurposes()
        {
            return new Damage();
        }

        protected Damage()
        {
            description = "This damage has a description";
            images = new List<string>() { "newImage" };
        }

        public static Damage CreateNewDamage(string description,
            ICollection<string> images)
        {
            return new Damage(description, images);
        }

        protected Damage(string descriptionToSet,
            ICollection<string> imagesToSet)
        {
            Description = descriptionToSet;
            Images = imagesToSet;
        }

        public override bool Equals(object obj)
        {
            Damage DamageToCompareAgainst = obj as Damage;
            if (Utilities.IsNotNull(DamageToCompareAgainst))
            {
                return Id.Equals(DamageToCompareAgainst.Id);
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