using Domain;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace Persistence
{
    internal class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<Location> Elements => GetElementsWith();

        public Location GetLocationWithName(string nameToLookup)
        {
            try
            {
                return elements.Single(l => l.Name.Equals(nameToLookup));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "lugar", nameToLookup);
                throw new RepositoryException(errorMessage);
            }
        }

        protected override bool ElementExistsInCollection(Location entityToUpdate)
        {
            return Utilities.IsNotNull(entityToUpdate) &&
                elements.Any(i => i.Id == entityToUpdate.Id);
        }
    }
}