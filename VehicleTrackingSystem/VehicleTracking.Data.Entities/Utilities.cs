using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    public static class Utilities
    {
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

        public static bool ValidYear(int value)
        {
            return value <= DateTime.Now.Year && value > 1900;
        }

        public static bool IsValidDate(DateTime value)
        {
            return ValidYear((int)value.Year);
        }

        public static bool ValidateInspection(User user, Location location)
        {
            if (IsValidUserInspection(user) && IsNotNull(location))
            {
                if (location.Type == LocationType.PORT)
                {
                    return user.Role == UserRoles.ADMINISTRATOR || user.Role == UserRoles.PORT_OPERATOR;
                }
                else
                {
                    return user.Role == UserRoles.ADMINISTRATOR || user.Role == UserRoles.YARD_OPERATOR;
                }
            }
            else
            {
                return false;
            }
        }

        private static UserRoles[] allowedUserRoles = { UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR, UserRoles.YARD_OPERATOR };

        public static bool IsValidUserInspection(User user)
        {
            return IsNotNull(user) ? allowedUserRoles.Contains(user.Role) : false;
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