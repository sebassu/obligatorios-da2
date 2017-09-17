using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    class VehicleRepository
    {
        public static IReadOnlyCollection<Vehicle> Elements
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

        public static Vehicle AddNewVehicle(VehicleType type, string brand, string model,
            int year, string color, string vin)
        {
            using (var context = new VTSystemContext())
            {
                bool vehicleIsNotRegistered = !ExistsVehicleWithVin(vin);
                if (vehicleIsNotRegistered)
                {
                    Vehicle vehicleToAdd = Vehicle.CreateNewVehicle(type, brand, model,
                        year, color, vin);
                    EntityFrameworkUtilities<Vehicle>.Add(context, vehicleToAdd);
                    return vehicleToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.VinMustBeUnique);
                }
            }
        }

        private static bool ExistsVehicleWithVin(string vehicleToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Vehicles.Any(v => v.Vin == vehicleToLookup);
            }
        }
    }
}
