using System.Collections.Generic;

namespace API.Services.Business_Logic
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