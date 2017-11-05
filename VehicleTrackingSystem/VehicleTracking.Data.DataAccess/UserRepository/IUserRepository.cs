using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IUserRepository
    {
        void AddNewUser(User userToAdd);
        IEnumerable<User> Elements { get; }
        User GetUserWithUsername(string usernameToLookup);
        void UpdateUser(User userToModify);
        void RemoveUserWithUsername(string usernameToRemove);
        bool ExistsUserWithUsername(string usernameToLookup);
        bool UsernameBelongsToLastAdministrator(string usernameToRemove);
    }
}