using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_ConcreteImportingStrategies
{
    public abstract class FileReadingImportingStrategy : IImportingStrategy
    {
        private const string pathParameterName = "Ubicacióndelarchivo";

        public Dictionary<string, Type> RequiredParameters =>
            new Dictionary<string, Type>() {
                { pathParameterName, typeof(Path) }
            };

        public IEnumerable<Vehicle> GetVehicles(IDictionary<string, object> parameters)
        {
            try
            {
                var pathOfXMLFile = parameters[pathParameterName] as string;
                IEnumerable<Vehicle> vehicles = GetVehicleEnumerationFromFile(pathOfXMLFile);
                SetStageData(vehicles);
                return vehicles;
            }
            catch (NullReferenceException)
            {
                throw ErrorOnParameterInput();
            }
            catch (KeyNotFoundException)
            {
                throw ErrorOnParameterInput();
            }
        }

        private void SetStageData(IEnumerable<Vehicle> vehicles)
        {
            foreach(Vehicle v in vehicles)
            {
                v.StagesData = new ProcessData();
            }
        }

        private static ImportingException ErrorOnParameterInput()
        {
            string errorMessage = string.Format(CultureInfo.CurrentCulture,
                ErrorMessages.IncompleteParameters, pathParameterName);
            return new ImportingException(errorMessage);
        }

        private IEnumerable<Vehicle> VehiclesToReturnFromFile(string pathOfXMLFile)
        {
            var vehicles = GetVehicleEnumerationFromFile(pathOfXMLFile);
            foreach (var vehicle in vehicles)
            {
                vehicle.StagesData = new ProcessData();
            }
            return vehicles;
        }

        protected abstract IEnumerable<Vehicle> GetVehicleEnumerationFromFile(string filePath);
    }
}