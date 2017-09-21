using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Damage
    {
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
                        ErrorMessages.DescriptionIsInvalid, "", value);
                    throw new DamageException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidDescription(string value)
        {
            return Utilities.IsNotEmpty(value) && Utilities.IsNotNull(value);
        }

        public List<string> Images {get; } = new List<string>();

        public void AddImage(string source)
        {
            if (IsValidImage(source))
            {
                Images.Add(source);
            }else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ImageIsInvalid, "", source);
                throw new DamageException(errorMessage);
            }
        }

        protected virtual bool IsValidImage(string source)
        {
            return Utilities.IsNotEmpty(source) && Utilities.IsNotNull(source) && !Images.Contains(source);
        } 

        internal static Damage InstanceForTestingPurposes()
        {
            return new Damage();
        }

        protected Damage()
        {
            description = "This damage has a description";
            Images.Add("newImage");
        }
    }
}
