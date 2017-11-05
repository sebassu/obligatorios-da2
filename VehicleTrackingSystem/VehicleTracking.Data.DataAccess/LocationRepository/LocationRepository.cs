using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
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
    }
}