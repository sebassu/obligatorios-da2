using Domain;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace API.Services.Business_Logic
{
    public class SubzoneServices : ISubzoneServices
    {
        internal IUnitOfWork Model { get; }
        internal IZoneRepository Zones { get; }
        internal ISubzoneRepository Subzones { get; }

        public SubzoneServices()
        {
            Model = new UnitOfWork();
            Zones = Model.Zones;
            Subzones = Model.Subzones;
        }

        public SubzoneServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Zones = Model.Zones;
            Subzones = Model.Subzones;
        }

        public int AddNewSubzoneFromData(string containerName,
            SubzoneDTO zoneDataToAdd)
        {
            if (Utilities.IsNotNull(zoneDataToAdd))
            {
                Zone container = Zones.GetZoneWithName(containerName);
                return AttemptToAddSubzone(container, zoneDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private int AttemptToAddSubzone(Zone container, SubzoneDTO subzoneData)
        {
            Subzone subzoneToAdd = subzoneData.ToSubzone(container);
            Subzones.AddNewSubzone(subzoneToAdd);
            Zones.UpdateZone(container);
            Model.SaveChanges();
            return subzoneToAdd.Id;
        }

        public IEnumerable<SubzoneDTO> GetRegisteredSubzones()
        {
            var result = new List<SubzoneDTO>();
            foreach (var zone in Subzones.Elements)
            {
                result.Add(SubzoneDTO.FromSubzone(zone));
            }
            return result.AsReadOnly();
        }

        public SubzoneDTO GetSubzoneWithId(int idToFind)
        {
            Subzone subzoneFound = Subzones.GetSubzoneWithId(idToFind);
            return SubzoneDTO.FromSubzone(subzoneFound);
        }

        public void ModifySubzoneWithId(int idToModify, SubzoneDTO subzoneDataToSet)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(subzoneDataToSet,
            delegate { AttemptToPerformModification(idToModify, subzoneDataToSet); });
        }

        private void AttemptToPerformModification(int idToModify, SubzoneDTO subzoneData)
        {
            Subzone subzoneFound = Subzones.GetSubzoneWithId(idToModify);
            subzoneData.SetDataToSubzone(subzoneFound);
            Subzones.UpdateSubzone(subzoneFound);
            Model.SaveChanges();
        }

        public void RemoveSubzoneWithId(int idToRemove)
        {
            Subzone subzoneToRemove = Subzones.GetSubzoneWithId(idToRemove);
            bool isNonEmptySubzone = subzoneToRemove.Vehicles.Any();
            if (isNonEmptySubzone)
            {
                throw new ServiceException(ErrorMessages.CannotRemoveNonEmptySubzone);
            }
            else
            {
                Subzones.RemoveSubzone(subzoneToRemove);
                Model.SaveChanges();
            }
        }
    }
}