using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Schema;
using System.Reflection;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_ConcreteImportingStrategies
{
    public class XMLConcreteImportingStrategy
        : FileReadingImportingStrategy
    {
        private const string xmlSchemaResourceName = "VehicleTracking_" +
            "ConcreteImportingStrategies.VehicleImportingXMLSchema.xsd";

        public XMLConcreteImportingStrategy() { }

        protected override IEnumerable<Vehicle> GetVehicleEnumerationFromFile(string filePath)
        {
            var vehicles = new List<Vehicle>();
            try
            {
                var document = GetXMLDocumentToUse(filePath);
                var vehiclesData = document.GetElementsByTagName("Vehiculos")
                    .Cast<XmlNode>().Single();
                foreach (XmlNode vehicleData in vehiclesData.ChildNodes)
                {
                    var vehicleToAdd = ProcessVehicleNode(vehicleData);
                    vehicles.Add(vehicleToAdd);
                }
                return vehicles;
            }
            catch (IOException exception)
            {
                throw new ImportingException(exception.Message);
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

        public override string ToString()
        {
            return "Importación desde archivo XML";
        }
    }
}