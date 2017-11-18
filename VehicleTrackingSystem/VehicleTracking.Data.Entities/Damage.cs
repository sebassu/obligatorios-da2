using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace VehicleTracking_Data_Entities
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

        public ICollection<ImageElement> ImageElements { get; set; }

        public ICollection<string> Images
        {
            get
            {
                var imageStringsToReturn = ImageElements.Select(i => i.StringifiedImage);
                return imageStringsToReturn.ToList();
            }
            set
            {
                if (IsValidImageCollection(value))
                {
                    var imageElementsToAdd = value.Select(i => ImageElement.FromImageData(i));
                    ImageElements = imageElementsToAdd.ToList();
                }
                else
                {
                    throw new DamageException(ErrorMessages.CollectionIsInvalid);
                }
            }
        }

        private bool IsValidImageCollection(ICollection<string> value)
        {
            return Utilities.IsNotNull(value) && value.Any();
        }

        internal static Damage InstanceForTestingPurposes()
        {
            return new Damage();
        }

        protected Damage()
        {
            description = "This damage has a description";
            ImageElements = new List<ImageElement>();
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