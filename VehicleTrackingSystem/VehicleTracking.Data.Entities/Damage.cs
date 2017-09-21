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
            return Utilities.IsNotNull(value) && Utilities.IsNotEmpty(value);
        }

        internal static Damage InstanceForTestingPurposes()
        {
            return new Damage();
        }

        protected Damage()
        {
            description = "This damage has a description";
        }
    }
}
