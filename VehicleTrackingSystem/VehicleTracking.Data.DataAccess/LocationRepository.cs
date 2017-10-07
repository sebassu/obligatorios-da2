using Domain;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Data.Entity;

namespace Persistence
{
    internal class LocationRepository : ILocationRepository
    {
        private VTSystemContext context;
        private DbSet<Location> locations;

        public LocationRepository(VTSystemContext someContext)
        {
            context = someContext;
        }

        public IEnumerable<Location> Elements => locations.ToList();

        public Location GetLocationWithName(string nameToLookup)
        {
            try
            {
                return locations.Single(l => l.Name.Equals(nameToLookup));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "lugar", nameToLookup);
                throw new RepositoryException(errorMessage);
            }
        }
    }
}