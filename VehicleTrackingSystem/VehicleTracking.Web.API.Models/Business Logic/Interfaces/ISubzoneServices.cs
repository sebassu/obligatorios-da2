using System.Collections.Generic;

namespace API.Services.Business_Logic
{
    public interface ISubzoneServices
    {
        int AddNewSubzoneFromData(string containerName,
            SubzoneDTO subzoneDataToAdd);
        IEnumerable<SubzoneDTO> GetRegisteredSubzones();
        SubzoneDTO GetSubzoneWithId(int idToFind);
        void ModifySubzoneWithId(int idToModify,
            SubzoneDTO subzoneDataToSet);
        void RemoveSubzoneWithId(int idToRemove);
    }
}
