using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IInspectionRepository
    {
        void AddNewInspection(Inspection inspectionToAdd);
        IEnumerable<Inspection> Elements { get; }
        Inspection GetInspectionWithId(int idToLookup);
    }
}
