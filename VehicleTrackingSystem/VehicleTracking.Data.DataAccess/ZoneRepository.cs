﻿using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Persistence
{
    internal class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(VTSystemContext someContext) : base(someContext) { }

        public int AddNewZone(Zone zoneToAdd)
        {
            Add(zoneToAdd);
            return zoneToAdd.Id;
        }

        public IEnumerable<Zone> Elements => GetElementsThat();

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

        public void RemoveZoneWithName(string nameToRemove)
        {
            var userToRemove = GetZoneWithName(nameToRemove);
            AttemptToRemove(userToRemove);
        }

        protected override bool ElementExistsInCollection(Zone value)
        {
            return Utilities.IsNotNull(value) && elements.Any(z => z.Id == value.Id);
        }
    }
}