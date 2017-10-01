using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    public static class Utilities
    {
        public const short minimumYear = 1900;

        private static readonly Regex phoneFormat =
            new Regex("^(?!00)[0-9]{8,9}$");

        public static bool IsNotNull(object value)
        {
            return value != null;
        }

        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool ContainsLettersDigitsOrSpacesOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterDigitOrSpace(c));
        }

        private static bool IsLetterDigitOrSpace(char value)
        {
            return IsLetterOrDigit(value) || char.IsWhiteSpace(value);
        }

        public static bool ContainsLettersOrDigitsOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterOrDigit(c));
        }

        private static bool IsLetterOrDigit(char value)
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

        public static bool IsValidYear(int value)
        {
            return value <= DateTime.Now.Year && value > minimumYear;
        }

        private const ushort VINLength = 17;
        public static bool IsValidVIN(string value)
        {
            return ContainsLettersOrDigitsOnly(value) && value.Length == VINLength;
        }
    }
}