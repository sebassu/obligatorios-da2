using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        public static void Remove(Vehicle elementToRemove)
        {
            EntityFrameworkUtilities<Vehicle>.Remove(elementToRemove);
        }

        public static void ModifyVehicle(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, int yearToSet, string colorToSet, string vinToSet)
        {
            try
            {
                AttemptToSetVehicleAttributes(vehicleToModify, typeToSet, brandToSet, modelToSet,
                    yearToSet, colorToSet, vinToSet);
            }
            catch (DataException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.ElementDoesNotExist, "Vehiculo");
                throw new RepositoryException(errorMessage);
            }
        }

        private static void AttemptToSetVehicleAttributes(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, int yearToSet, string colorToSet, string vinToSet)
        {
            using (var context = new VTSystemContext())
            {
                EntityFrameworkUtilities<Vehicle>.AttachIfIsValid(context, vehicleToModify);
                if (ChangeCausesRepeatedVin(vehicleToModify, vinToSet))
                {
                    throw new RepositoryException(ErrorMessages.VinMustBeUnique);
                }
                else
                {
                    SetVehicleAttributes(vehicleToModify, typeToSet, brandToSet, modelToSet,
                        yearToSet, colorToSet, vinToSet);
                    context.SaveChanges();
                }
            }
        }

        private static bool ChangeCausesRepeatedVin(Vehicle vehicleToModify, string vinToSet)
        {
            bool vinChanges = vehicleToModify.Vin != vinToSet;
            return vinChanges && ExistsVehicleWithVin(vinToSet);
        }

        private static void SetVehicleAttributes(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, int yearToSet, string colorToSet, string vinToSet)
        {
            vehicleToModify.Type = typeToSet;
            vehicleToModify.Brand = brandToSet;
            vehicleToModify.Model = modelToSet;
            vehicleToModify.Year = yearToSet;
            vehicleToModify.Color = colorToSet;
            vehicleToModify.Vin = vinToSet;
        }
    }
}
