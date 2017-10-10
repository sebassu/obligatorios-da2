using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Elements { get; }
        Location GetLocationWithName(string nameToLookup);
    }
}
