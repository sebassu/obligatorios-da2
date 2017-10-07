using System.Collections.Generic;

namespace API.Services.Business_Logic
{
    public interface IInspectionServices
    {
        int AddNewInspectionFromData(string vehicleVIN,
            InspectionDTO inspectionDataToAdd);
        IEnumerable<InspectionDTO> GetRegisteredInspections();
        InspectionDTO GetInspectionWithId(string usernameToLookup);
    }
}