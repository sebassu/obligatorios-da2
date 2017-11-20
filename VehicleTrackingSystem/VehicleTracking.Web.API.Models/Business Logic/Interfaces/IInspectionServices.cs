using System;
using System.Collections.Generic;

namespace API.Services
{
    public interface IInspectionServices
    {
        string AddNewPortInspectionFromData(string vehicleVIN,
            string currentUsername, InspectionDTO inspectionDataToAdd);
        string AddNewYardInspectionFromData(string vehicleVIN,
            string currentUsername, InspectionDTO inspectionDataToAdd);
        IEnumerable<InspectionDTO> GetRegisteredInspections();
        InspectionDTO GetInspectionWithId(Guid idToLookup);
    }
}