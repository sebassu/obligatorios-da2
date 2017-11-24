using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ISubzoneRepository
    {
        void AddNewSubzone(Subzone subzoneToAdd);
        IEnumerable<Subzone> Elements { get; }
        Subzone GetSubzoneWithId(int idToFind);
        void UpdateSubzone(Subzone subzoneToModify);
        void RemoveSubzone(Subzone subzoneToRemove);
    }
}