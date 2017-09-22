using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Inspection
    {

        public int Id { get; set; }

        private DateTime dateTime;
        public DateTime DateTime {
            get { return dateTime; }
            set {
                if (IsValidDate(value))
                {
                    dateTime = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.DateIsInvalid, value);
                    throw new InspectionException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidDate(DateTime value)
        {
            return Utilities.IsValidDate(value);
        }

        internal static Inspection InstanceForTestingPurposes()
        {
            return new Inspection();
        }

        protected Inspection()
        {
            dateTime = new DateTime(2017, 9, 22, 10, 8, 0);
        }
    }
}
