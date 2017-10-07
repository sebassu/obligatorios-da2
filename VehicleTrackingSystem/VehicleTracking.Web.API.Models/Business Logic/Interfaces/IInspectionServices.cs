using System.Collections.Generic;

namespace API.Services
{
    public interface IInspectionServices
    {
        int AddNewPortInspectionFromData(string vehicleVIN,
            string currentUsername, InspectionDTO inspectionDataToAdd);
        int AddNewYardInspectionFromData(string vehicleVIN,
            string currentUsername, InspectionDTO inspectionDataToAdd);
        IEnumerable<InspectionDTO> GetRegisteredInspections();
        InspectionDTO GetInspectionWithId(int idToLookup);
    }
}