using System.Linq;

namespace Domain
{
    public static class Utilities
    {
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
    }
}