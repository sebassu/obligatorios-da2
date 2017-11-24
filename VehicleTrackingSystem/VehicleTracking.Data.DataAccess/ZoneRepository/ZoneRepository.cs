using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(VTSystemContext someContext) : base(someContext) { }

        public void AddNewZone(Zone zoneToAdd)
        {
            Add(zoneToAdd);
        }

        public IEnumerable<Zone> Elements => GetElementsWith();

        public Zone GetZoneWithName(string nameToFind)
        {
            try
            {
                return elements.Include("Subzones.Container")
                    .Single(z => z.Name.Equals(nameToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "nombre de zona", nameToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateZone(Zone zoneToModify)
        {
            Update(zoneToModify);
        }

        public void RemoveZone(Zone zoneToRemove)
        {
            AttemptToRemove(zoneToRemove);
        }

        internal override bool ElementExistsInCollection(Zone value)
        {
            return Utilities.IsNotNull(value) && elements.Any(z => z.Id == value.Id);
        }

        public bool ExistsZoneWithName(string name)
        {
            return elements.Any(z => z.Name.Equals(name));
        }
    }
}