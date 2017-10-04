using Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Services")]
namespace Persistence
{
    internal class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VTSystemContext someContext) : base(someContext) { }

        public IEnumerable<Vehicle> Elements => GetElementsWith();

        public int AddNewVehicle(Vehicle vehicleToAdd)
        {
            Add(vehicleToAdd);
            return vehicleToAdd.Id;
        }

        public bool ExistsVehicleWithVIN(string VINToLookup)
        {
            return elements.Any(v => v.VIN == VINToLookup);
        }

        public Vehicle GetVehicleWithVIN(string vinToFind)
        {
            try
            {
                return elements.Single(v => v.VIN.Equals(vinToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "VIN", vinToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateVehicle(Vehicle modifiedVehicle)
        {
            Update(modifiedVehicle);
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            var vehicleToRemove = GetVehicleWithVIN(vinToRemove);
            AttemptToRemove(vehicleToRemove);
        }

        protected override bool ElementExistsInCollection(Vehicle value)
        {
            return Utilities.IsNotNull(value) && elements.Any(v => v.Id == value.Id);
        }
    }
}