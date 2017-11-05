using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_ConcreteImportingStrategies
{
    public class JSONConcreteImportingStrategy
        : FileReadingImportingStrategy
    {
        protected override IEnumerable<Vehicle> GetVehicleEnumerationFromFile(string filePath)
        {
            try
            {
                string jsonFile = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Vehicle>>(jsonFile);
            }
            catch (IOException exception)
            {
                throw new ImportingException(exception.Message);
            }
            catch (JsonException exception)
            {
                throw new ImportingException(exception.Message);
            }
        }
    }
}