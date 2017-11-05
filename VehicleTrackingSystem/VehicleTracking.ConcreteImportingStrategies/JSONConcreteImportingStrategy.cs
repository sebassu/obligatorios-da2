using Domain;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ImportingStrategies
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
            catch (IOException)
            {
                throw new ImportingException(ErrorMessages.FileNotFound);
            }
            catch (JsonException exception)
            {
                throw new ImportingException(exception.Message);
            }
        }
    }
}