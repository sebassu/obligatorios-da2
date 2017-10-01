using Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Services")]
namespace Persistence
{
    internal class VehicleRepository : IVehicleRepository
    {
        public int AddNewVehicle(Vehicle vehicleToAdd)
        {
            using (var context = new VTSystemContext())
            {
                ValidateParameterIsNotNull(vehicleToAdd);
                if (ExistsVehicleWithVIN(vehicleToAdd.VIN, context))
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.FieldMustBeUnique, "VIN");
                    throw new RepositoryException(errorMessage);
                }
                else
                {
                    EntityFrameworkUtilities<Vehicle>.Add(context, vehicleToAdd);
                    return vehicleToAdd.Id;
                }
            }
        }

        private void ValidateParameterIsNotNull(Vehicle vehicleToAdd)
        {
            if (vehicleToAdd == null)
            {
                throw new ArgumentNullException(ErrorMessages.NullObjectRecieved);
            }
        }

        public IEnumerable<Vehicle> Elements
        {
            get
            {
                using (var context = new VTSystemContext())
                {
                    var elements = context.Vehicles;
                    return elements.ToList();
                }
            }
        }

        public bool ExistsVehicleWithVIN(string VINToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return ExistsVehicleWithVIN(VINToLookup, context);
            }
        }

        private static bool ExistsVehicleWithVIN(string VINToLookup,
            VTSystemContext context)
        {
            return context.Vehicles.Any(v => v.VIN == VINToLookup);
        }

        public Vehicle GetVehicleWithVIN(string vinToFind)
        {
            using (var context = new VTSystemContext())
            {
                return AttemptToGetVehicleWithVIN(vinToFind, context);
            }
        }

        private static Vehicle AttemptToGetVehicleWithVIN(string vinToFind,
            VTSystemContext context)
        {
            try
            {
                var elements = context.Set<Vehicle>();
                return elements.Single(u => u.VIN.Equals(vinToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindUser, vinToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateVehicle(Vehicle vehicleToModify)
        {
            EntityFrameworkUtilities<Vehicle>.Update(vehicleToModify);
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            using (var context = new VTSystemContext())
            {
                var vehicleToRemove = AttemptToGetVehicleWithVIN(vinToRemove, context);
                EntityFrameworkUtilities<Vehicle>.AttemptToRemove(vehicleToRemove, context);
            }
        }
    }
}