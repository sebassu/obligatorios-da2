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
            short year, string color, string VIN)
        {
            using (var context = new VTSystemContext())
            {
                bool vehicleIsNotRegistered = !ExistsVehicleWithVIN(VIN);
                if (vehicleIsNotRegistered)
                {
                    Vehicle vehicleToAdd = Vehicle.CreateNewVehicle(type, brand, model,
                        year, color, VIN);
                    EntityFrameworkUtilities<Vehicle>.Add(context, vehicleToAdd);
                    return vehicleToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.VINMustBeUnique);
                }
            }
        }

        private static bool ExistsVehicleWithVIN(string VINToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Vehicles.Any(v => v.VIN == VINToLookup);
            }
        }

        public static void Remove(Vehicle elementToRemove)
        {
            EntityFrameworkUtilities<Vehicle>.Remove(elementToRemove);
        }

        public static void ModifyVehicle(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, short yearToSet, string colorToSet, string VINToSet)
        {
            try
            {
                AttemptToSetVehicleAttributes(vehicleToModify, typeToSet, brandToSet, modelToSet,
                    yearToSet, colorToSet, VINToSet);
            }
            catch (DataException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.ElementDoesNotExist, "Vehiculo");
                throw new RepositoryException(errorMessage);
            }
        }

        private static void AttemptToSetVehicleAttributes(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, short yearToSet, string colorToSet, string VINToSet)
        {
            using (var context = new VTSystemContext())
            {
                EntityFrameworkUtilities<Vehicle>.AttachIfIsValid(context, vehicleToModify);
                if (ChangeCausesRepeatedVIN(vehicleToModify, VINToSet))
                {
                    throw new RepositoryException(ErrorMessages.VINMustBeUnique);
                }
                else
                {
                    SetVehicleAttributes(vehicleToModify, typeToSet, brandToSet, modelToSet,
                        yearToSet, colorToSet, VINToSet);
                    context.SaveChanges();
                }
            }
        }

        private static bool ChangeCausesRepeatedVIN(Vehicle vehicleToModify, string VINToSet)
        {
            bool VINChanges = vehicleToModify.VIN != VINToSet;
            return VINChanges && ExistsVehicleWithVIN(VINToSet);
        }

        private static void SetVehicleAttributes(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, short yearToSet, string colorToSet, string VINToSet)
        {
            vehicleToModify.Type = typeToSet;
            vehicleToModify.Brand = brandToSet;
            vehicleToModify.Model = modelToSet;
            vehicleToModify.Year = yearToSet;
            vehicleToModify.Color = colorToSet;
            vehicleToModify.VIN = VINToSet;
        }
    }
}
