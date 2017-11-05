using Domain;
using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Schema;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

namespace ImportingStrategies
{
    public class XMLConcreteImportingStrategy
        : IImportingStrategy
    {
        private const string pathParameterName = "Ubicación del archivo";
        private const string xmlSchemaResourceName = "ImportingStrategies." +
            "VehicleImportingXMLSchema.xsd";

        public XMLConcreteImportingStrategy() { }

        public IEnumerable<Vehicle> GetVehicles(IDictionary<string,
            object> parameters)
        {
            try
            {
                var pathOfXMLFile = parameters[pathParameterName] as string;
                return GetVehicleEnumerationFromFile(pathOfXMLFile);
            }
            catch (SystemException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.IncompleteParameters, pathParameterName);
                throw new ImportingException(errorMessage);
            }
        }

        private IEnumerable<Vehicle> GetVehicleEnumerationFromFile(string pathOfXMLFile)
        {
            var vehicles = new List<Vehicle>();
            try
            {
                var document = GetXMLDocumentToUse(pathOfXMLFile);
                var vehiclesData = document.GetElementsByTagName("Vehiculos")
                    .Cast<XmlNode>().Single();
                foreach (XmlNode vehicleData in vehiclesData.ChildNodes)
                {
                    var vehicleToAdd = ProcessVehicleNode(vehicleData);
                    vehicles.Add(vehicleToAdd);
                }
                return vehicles;
            }
            catch (FileNotFoundException)
            {
                throw new ImportingException(ErrorMessages.FileNotFound);
            }
            catch (XmlException)
            {
                throw new ImportingException(ErrorMessages.ErrorWhenReadingFile);
            }
        }

        private Vehicle ProcessVehicleNode(XmlNode vehicleData)
        {
            VehicleType type = GetParsedVehicleType(vehicleData);
            string brand = vehicleData["Marca"].InnerText;
            string model = vehicleData["Modelo"].InnerText;
            short year = short.Parse(vehicleData["Año"].InnerText);
            string color = vehicleData["Color"].InnerText;
            string vin = vehicleData["VIN"].InnerText;
            return Vehicle.CreateNewVehicle(type, brand,
                model, year, color, vin);
        }

        private static VehicleType GetParsedVehicleType(XmlNode vehicleData)
        {
            try
            {
                string vehicleTypeName = vehicleData["Tipo"].InnerText;
                return (VehicleType)Enum.Parse(typeof(VehicleType),
                    vehicleTypeName);
            }
            catch (ArgumentException)
            {
                throw new ImportingException(ErrorMessages.ErrorWhenReadingFile);
            }
        }

        private XmlDocument GetXMLDocumentToUse(string pathOfXMLFile)
        {
            var validationSettings = GetSettingsForXMLReader();
            var xmlFileToRead = File.OpenText(pathOfXMLFile);
            var reader = XmlReader.Create(xmlFileToRead, validationSettings);
            XmlDocument result = new XmlDocument();
            result.Load(reader);
            return result;
        }

        private XmlReaderSettings GetSettingsForXMLReader()
        {
            var settings = new XmlReaderSettings();
            Assembly currentAssembly = GetType().Assembly;
            using (Stream schemaStream = currentAssembly
                .GetManifestResourceStream(xmlSchemaResourceName))
            {
                using (XmlReader schemaReader = XmlReader.Create(schemaStream))
                {
                    settings.ValidationType = ValidationType.Schema;
                    settings.Schemas.Add(null, schemaReader);
                    settings.ValidationEventHandler
                        += new ValidationEventHandler(InformOfFileReadingError);
                }
            }
            return settings;
        }

        private void InformOfFileReadingError(object sender = null,
            ValidationEventArgs e = null)
        {
            throw new ImportingException(ErrorMessages.ErrorWhenReadingFile);
        }

        public Dictionary<string, Type> RequiredParameters =>
            new Dictionary<string, Type>() {
                { pathParameterName, typeof(Path) }
            };
    }
}