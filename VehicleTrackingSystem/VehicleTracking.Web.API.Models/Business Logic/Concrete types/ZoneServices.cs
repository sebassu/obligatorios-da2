using Persistence;
using System.Collections.Generic;
using System.Globalization;
using Domain;
using System.Linq;

namespace API.Services.Business_Logic
{
    public class ZoneServices : IZoneServices
    {
        internal IUnitOfWork Model { get; }
        internal IZoneRepository Zones { get; }

        public ZoneServices()
        {
            Model = new UnitOfWork();
            Zones = Model.Zones;
        }

        public ZoneServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Zones = Model.Zones;
        }

        public int AddNewZoneFromData(ZoneDTO zoneDataToAdd)
        {
            if (Utilities.IsNotNull(zoneDataToAdd))
            {
                return AttemptToAddZone(zoneDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private int AttemptToAddZone(ZoneDTO zoneDataToAdd)
        {
            bool nameIsNotRegistered =
                !Zones.ExistsZoneWithName(zoneDataToAdd.Name);
            if (nameIsNotRegistered)
            {
                Zone zoneToAdd = zoneDataToAdd.ToZone();
                Zones.AddNewZone(zoneToAdd);
                Model.SaveChanges();
                return zoneToAdd.Id;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de zona");
                throw new ServiceException(errorMessage);
            }
        }

        public IEnumerable<ZoneDTO> GetRegisteredZones()
        {
            var result = new List<ZoneDTO>();
            foreach (var zone in Zones.Elements)
            {
                result.Add(ZoneDTO.FromZone(zone));
            }
            return result.AsReadOnly();
        }

        public ZoneDTO GetZoneWithName(string nameToLookup)
        {
            Zone zoneFound = Zones.GetZoneWithName(nameToLookup);
            return ZoneDTO.FromZone(zoneFound);
        }

        public void ModifyZoneWithName(string nameToModify, ZoneDTO zoneDataToSet)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(zoneDataToSet,
            delegate { AttemptToPerformModification(nameToModify, zoneDataToSet); });
        }

        private void AttemptToPerformModification(string nameToModify, ZoneDTO zoneData)
        {
            Zone zoneFound = Zones.GetZoneWithName(nameToModify);
            zoneData.SetDataToZone(zoneFound);
            Zones.UpdateZone(zoneFound);
            Model.SaveChanges();
        }

        public void RemoveZoneWithName(string nameToRemove)
        {
            Zone zoneToRemove = Zones.GetZoneWithName(nameToRemove);
            bool isEmptyZone = zoneToRemove.Subzones.Any();
            if (isEmptyZone)
            {
                Zones.RemoveZone(zoneToRemove);
                Model.SaveChanges();
            }
            else
            {
                throw new ServiceException(ErrorMessages.CannotRemoveNonEmptyZone);
            }
        }
    }
}