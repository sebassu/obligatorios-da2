using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Flow
    {
        private const string separator = ",";

        public string EncodedSubzoneNames { get; set; }

        private IEnumerable<string> requiredSubzoneNames;

        public IEnumerable<string> RequiredSubzoneNames
        {
            get { return requiredSubzoneNames; }
            internal set
            {
                if (IsNonEmptySubzoneNameCollection(value))
                {
                    requiredSubzoneNames = value;
                }
                else
                {
                    throw new FlowException(ErrorMessages.FlowMustContainSubzones);
                }
            }
        }

        private bool IsNonEmptySubzoneNameCollection(IEnumerable<string> value)
        {
            return Utilities.IsNotNull(value) && value.Any();
        }

        internal static Flow InstanceForTestingPurposes()
        {
            return new Flow();
        }

        private Flow() { }

        public static Flow FromSubzoneNames(IEnumerable<string> subzoneNames)
        {
            return new Flow(subzoneNames);
        }

        public Flow(IEnumerable<string> subzoneNamesToSet)
        {
            RequiredSubzoneNames = subzoneNamesToSet;
            EncodedSubzoneNames = string.Join(separator, subzoneNamesToSet);
        }
    }
}