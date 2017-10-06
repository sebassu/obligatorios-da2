using Persistence;
using System.Collections.Generic;
using System;
using System.Globalization;
using Domain;

namespace API.Services.Business_Logic
{
    public class ZoneSubzoneServices : IZoneSubzoneServices
    {
        internal IUnitOfWork Model { get; }
        internal IZoneRepository Zones { get; }
        internal ISubzoneRepository Subzones { get; }

        public ZoneSubzoneServices()
        {
            Model = new UnitOfWork();
            Zones = Model.Zones;
            Subzones = Model.Subzones;
        }

        public ZoneSubzoneServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Zones = Model.Zones;
            Subzones = Model.Subzones;
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
            throw new NotImplementedException();
        }

        public IEnumerable<SubzoneDTO> GetRegisteredSubzones()
        {
            throw new NotImplementedException();
        }

        public ZoneDTO GetZoneWithName(string vinToLookup)
        {
            throw new NotImplementedException();
        }

        public SubzoneDTO GetSubzoneWithId(string vinToLookup)
        {
            throw new NotImplementedException();
        }

        public void ModifyZoneWithName(string nameToModify, ZoneDTO zoneDataToSet)
        {
            throw new NotImplementedException();
        }

        public void ModifySubzoneWithId(int idToModify, SubzoneDTO subzoneDataToSet)
        {
            throw new NotImplementedException();
        }

        public void RemoveZoneWithName(string vinToRemove)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubzoneWithId(int idToRemove)
        {
            throw new NotImplementedException();
        }

        public int AddNewSubzoneFromData(string containerName, SubzoneDTO subzoneDataToAdd)
        {
            throw new NotImplementedException();
        }
    }
}