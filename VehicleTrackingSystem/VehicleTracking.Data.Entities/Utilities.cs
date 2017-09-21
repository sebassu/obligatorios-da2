using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    public static class Utilities
    {
        private static readonly Regex phoneFormat =
            new Regex("^(?!00)[0-9]{8,9}$");

        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(object value)
        {
            return value != null;
        }

        public static bool ContainsLettersOrDigitsOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterOrNumber(c));
        }

        private static bool IsLetterOrNumber(char value)
        {
            return char.IsLetter(value) || char.IsNumber(value);
        }

        public static bool ContainsLettersOrSpacesOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterOrSpace(c));
        }

        private static bool IsLetterOrSpace(char value)
        {
            return char.IsLetter(value) || char.IsWhiteSpace(value);
        }

        public static bool HasValidPhoneFormat(string value)
        {
            return IsNotNull(value) && phoneFormat.IsMatch(value);
        }

        public static bool ValidYear(int value)
        {
            return value <= System.DateTime.Now.Year && value > 1900;
        }
    }
}