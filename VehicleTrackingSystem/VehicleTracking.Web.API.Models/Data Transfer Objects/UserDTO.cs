﻿using System;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    [Serializable]
    public class UserDTO
    {
        [Required]
        public UserRoles Role { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public UserDTO() { }

        internal static UserDTO FromUser(User someUser)
        {
            return new UserDTO(someUser);
        }

        private UserDTO(User someUser) : this(someUser.Role, someUser.FirstName,
            someUser.LastName, someUser.Username, someUser.Password.Length.ToString(),
            someUser.PhoneNumber)
        { }

        internal static UserDTO FromData(UserRoles role, string firstName, string lastName,
            string username, string password, string phoneNumber)
        {
            return new UserDTO(role, firstName, lastName, username, password, phoneNumber);
        }

        private UserDTO(UserRoles roleToSet, string firstNameToSet, string lastNameToSet,
            string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            Role = roleToSet;
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Username = usernameToSet;
            Password = passwordToSet;
            PhoneNumber = phoneNumberToSet;
        }

        internal User ToUser()
        {
            return User.CreateNewUser(Role, FirstName, LastName,
                Username, Password, PhoneNumber);
        }

        internal void SetDataToUser(User userToModify)
        {
            userToModify.Role = Role;
            userToModify.FirstName = FirstName;
            userToModify.LastName = LastName;
            userToModify.Username = Username;
            userToModify.Password = Password;
            userToModify.PhoneNumber = PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            UserDTO dtoToCompareAgainst = obj as UserDTO;
            if (Utilities.IsNotNull(dtoToCompareAgainst))
            {
                return Username.Equals(dtoToCompareAgainst.Username);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}