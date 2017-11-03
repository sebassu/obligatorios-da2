using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Flow
    {
        private const char separator = ',';

        private string encodedSubzoneNames;
        public string EncodedSubzoneNames
        {
            get { return encodedSubzoneNames; }
            set
            {
                SetRequiredSubzoneNamesEnumeration(value);
                encodedSubzoneNames = value;
            }
        }

        private void SetRequiredSubzoneNamesEnumeration(string value)
        {
            var stringToProcess = value ?? "";
            var subzoneNamesToSet = stringToProcess.Split(separator);
            RequiredSubzoneNames = subzoneNamesToSet;
        }

        private IEnumerable<string> requiredSubzoneNames;

        public IEnumerable<string> RequiredSubzoneNames
        {
            get { return requiredSubzoneNames; }
            internal set
            {
                if (IsValidSubzoneNameCollection(value))
                {
                    requiredSubzoneNames = value;
                }
                else
                {
                    throw new FlowException(ErrorMessages.FlowSubzonesAreInvalid);
                }
            }
        }

        private bool IsValidSubzoneNameCollection(IEnumerable<string> subzoneNames)
        {
            bool isNonEmpty = Utilities.IsNotNull(subzoneNames) && subzoneNames.Any();
            return isNonEmpty && subzoneNames.All(n => Subzone.IsValidName(n));
        }

        internal static Flow InstanceForTestingPurposes()
        {
            return new Flow();
        }

        protected Flow() { }

        public static Flow FromSubzoneNames(IEnumerable<string> subzoneNames)
        {
            return new Flow(subzoneNames);
        }

        private Flow(IEnumerable<string> subzoneNamesToSet)
        {
            RequiredSubzoneNames = subzoneNamesToSet;
            EncodedSubzoneNames = string.Join(separator.ToString(),
                subzoneNamesToSet);
        }
    }
}