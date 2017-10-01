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

        public void AddNewZone(Zone zoneToAdd)
        {
            using (var context = new VTSystemContext())
            {
                bool zoneIsNotRegistered = !ExistsZoneWithName(zoneToAdd.Name);
                if (zoneIsNotRegistered)
                {
                    EntityFrameworkUtilities<Zone>.Add(context, zoneToAdd);
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.VINMustBeUnique);
                }
            }
        }

        private static bool ExistsZoneWithName(string nameToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Zones.Any(v => v.Name == nameToLookup);
            }
        }
    }
}
