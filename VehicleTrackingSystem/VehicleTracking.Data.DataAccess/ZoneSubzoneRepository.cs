using System.Collections.Generic;
using System.Linq;
using Domain;

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
    }
}
