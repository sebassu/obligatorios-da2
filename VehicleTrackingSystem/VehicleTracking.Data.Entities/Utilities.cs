using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    public static class Utilities
    {
        public const short minimumValidYear = 1900;

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

        public static bool IsValidItemEnumeration(IEnumerable value)
        {
            if (IsNotNull(value))
            {
                return EnumerationIsNonEmptyAndContainsNoDuplicates(value);
            }
            else
            {
                return false;
            }
        }

        private static bool EnumerationIsNonEmptyAndContainsNoDuplicates(IEnumerable value)
        {
            IEnumerable<object> castCollection = value.Cast<object>();
            return castCollection.Any() &&
                castCollection.Distinct().Count() == castCollection.Count();
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

        internal static bool IsValidDate(DateTime value)
        {
            return value <= DateTime.Now && value.Year > minimumValidYear;
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

        public static bool ContainsLettersOrSpacesOrDigitsOnly(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => IsLetterOrSpaceOrDigit(c)) &&
                !ContainsOnlyDigits(value);
        }

        private static bool ContainsOnlyDigits(string value)
        {
            return value.ToCharArray().All(c => IsDigit(c));
        }

        private static bool IsDigit(char value)
        {
            return char.IsDigit(value);
        }

        private static bool IsLetterOrSpaceOrDigit(char value)
        {
            return char.IsLetter(value) || char.IsWhiteSpace(value) || char.IsDigit(value);
        }

        public static bool HasValidPhoneFormat(string value)
        {
            return IsNotNull(value) && phoneFormat.IsMatch(value);
        }

        public static bool IsValidYear(int value)
        {
            return value <= DateTime.Now.Year && value > minimumValidYear;
        }

        private const ushort VINLength = 17;
        public static bool IsValidVIN(string value)
        {
            return ContainsLettersOrDigitsOnly(value) && value.Length == VINLength;
        }

        public static bool ValidMinimumCapacity(int value)
        {
            return value > 0;
        }
    }
}