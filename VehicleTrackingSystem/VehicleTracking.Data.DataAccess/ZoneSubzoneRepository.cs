﻿using System.Collections.Generic;
using System.Linq;
using Domain;
using System;
using System.Globalization;
using System.Data.Entity;

namespace Persistence
{
    public class ZoneSubzoneRepository
    {
        public IEnumerable<Zone> ZoneElements
        {
            get
            {
                using (var context = new VTSystemContext())
                {
                    var elements = context.Zones;
                    return elements.ToList();
                }
            }
        }

        public IEnumerable<Subzone> SubzoneElements
        {
            get
            {
                using (var context = new VTSystemContext())
                {
                    var elements = context.Subzones;
                    return elements.ToList();
                }
            }
        }

        public void AddNewZone(Zone zoneToAdd)
        {
            using (var context = new VTSystemContext())
            {
                if (Utilities.IsNotNull(zoneToAdd))
                {
                    bool zoneIsNotRegistered = !ExistsZoneWithName(zoneToAdd.Name);
                    if (zoneIsNotRegistered)
                    {
                        EntityFrameworkUtilities<Zone>.Add(context, zoneToAdd);
                    }
                    else
                    {
                        throw new RepositoryException(ErrorMessages.ZoneNameMustBeUnique);
                    }
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.NullIDRecieved);
                }
            }
        }

        public void UpdateZone(Zone zoneToModify)
        {
            if (Utilities.IsNotNull(zoneToModify))
            {
                EntityFrameworkUtilities<Zone>.Update(zoneToModify);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.NullObjectRecieved);
            }
        }

        public void RemoveZoneWithName(string nameToRemove)
        {
            using (var context = new VTSystemContext())
            {
                var zoneToRemove = AttemptToGetZoneWithName(nameToRemove, context);
                if (zoneToRemove.Subzones == null || zoneToRemove.Subzones.Count < 1)
                {
                    EntityFrameworkUtilities<Zone>.AttemptToRemove(zoneToRemove, context);
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                                        ErrorMessages.CouldNotFindElement, "");
                    throw new RepositoryException(errorMessage);
                }
            }
        }

        private static Zone AttemptToGetZoneWithName(string nameToFind,
            VTSystemContext context)
        {
            try
            {
                var elements = context.Set<Zone>();
                return elements.Single(z => z.Name.Equals(nameToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindElement, nameToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        private static bool ExistsZoneWithName(string nameToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Zones.Any(v => v.Name == nameToLookup);
            }
        }

        public void AddNewSubzone(Subzone subzoneToAdd)
        {
            using (var context = new VTSystemContext())
            {
                if (Utilities.IsNotNull(subzoneToAdd))
                {
                    bool zoneIsRegistered = ExistsZoneWithName(subzoneToAdd.ContainerZone.Name);
                    if (zoneIsRegistered)
                    {
                        subzoneToAdd.ContainerZone.Subzones.Add(subzoneToAdd);
                        context.Entry(subzoneToAdd.ContainerZone).State = EntityState.Modified;
                        EntityFrameworkUtilities<Subzone>.Add(context, subzoneToAdd);
                    }
                    else
                    {
                        throw new RepositoryException(ErrorMessages.SubzoneNameMustBeUniqueSameZone);
                    }
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.NullObjectRecieved);
                }
            }
        }

        public void UpdateSubzone(Subzone subzoneToModify)
        {
            if (Utilities.IsNotNull(subzoneToModify))
            {
                EntityFrameworkUtilities<Subzone>.Update(subzoneToModify);
            }
            else
            {
                throw new RepositoryException(ErrorMessages.NullObjectRecieved);
            }
        }

        public void RemoveSubzoneWithId(int id)
        {
            using (var context = new VTSystemContext())
            {
                var subzoneToRemove = AttemptToGetSubzoneWithId(id, context);
                if (subzoneToRemove.Vehicles == null || subzoneToRemove.Vehicles.Count < 1)
                {
                    subzoneToRemove.ContainerZone.Subzones.Remove(subzoneToRemove);
                    EntityFrameworkUtilities<Subzone>.AttemptToRemove(subzoneToRemove, context);
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                                        ErrorMessages.CouldNotFindElement, "");
                    throw new RepositoryException(errorMessage);
                }
            }
        }

        private static Subzone AttemptToGetSubzoneWithId(int id,
            VTSystemContext context)
        {
            try
            {
                var elements = context.Set<Subzone>();
                return elements.Single(s => s.Id.Equals(id));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindElement, "");
                throw new RepositoryException(errorMessage);
            }
        }
    }
}
