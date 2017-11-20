using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_DataAccess;

namespace API.Services
{
    public class LocationServices : ILocationServices
    {
        internal IUnitOfWork Model { get; }
        internal ILocationRepository Locations { get; }

        public LocationServices()
        {
            Model = new UnitOfWork();
            Locations = Model.Locations;
        }

        public IEnumerable<string> GetRegisteredPorts()
        {
            return Locations.Ports.Select(p => p.Name);
        }

        public IEnumerable<string> GetRegisteredYards()
        {
            return Locations.Yards.Select(p => p.Name); ;
        }
    }
}