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

        private List<string> images;
        public List<string> Images
        {
            get { return images; }
            set
            {
                if (IsValidList(value))
                {
                    images = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ListIsInvalid, value);
                    throw new DamageException(errorMessage);
                }
            }
        }

        protected bool IsValidList(List<string> value)
        {
            return Utilities.IsNotNull(value) ? value.Count > 0 : false;
        }

        public void AddImage(string source)
        {
            if (IsValidImage(source))
            {
                Images.Add(source);
            }
            else
            {
                throw new DamageException(ErrorMessages.ImageIsInvalid);
            }
        }

        protected virtual bool IsValidImage(string source)
        {
            return Utilities.IsNotEmpty(source) && !Images.Contains(source);
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

        public static Damage CreateNewDamage(string description, List<string> images)
        {
            return new Damage(description, images);
        }

        protected Damage(string descriptionToSet, List<string> imagesToSet)
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