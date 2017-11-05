using System;
using System.IO;
using System.Linq;
using VehicleTracking_Data_Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VehicleTracking_ConcreteImportingStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Strategies_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class JSONConcreteImportingStrategyTests
    {
        private static IImportingStrategy testingStrategy;
        private static string testFileLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + @"\";
        private static readonly IEnumerable<Vehicle> expectedVehicles =
            new List<Vehicle>()
            {
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                    "Barchetta", 1981, "Red", "RUSH2112MVNGPICRS"),
                Vehicle.CreateNewVehicle(VehicleType.VAN, "Renault",
                    "Kangoo", 2001, "Gris claro", "ASNDJFU1258741SMD")
            }.AsReadOnly();

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingStrategy = new JSONConcreteImportingStrategy();
        }

        [TestMethod]
        public void JSONCISGetRequiredParametersTest()
        {
            var expectedResult = new Dictionary<string, Type>() {
                { "Ubicación del archivo", typeof(Path) }
            };
            var obtainedResult = testingStrategy.RequiredParameters;
            CollectionAssert.AreEqual(expectedResult,
                obtainedResult);
        }

        [TestMethod]
        public void JSONCISGetVehiclesFromJSONTestFileValidTest()
        {
            var obtainedResult =
                RunTestForFileWithName("VehicleJSONImportingTestFile.json");
            CollectionAssert.AreEqual(expectedVehicles.ToList(),
                obtainedResult.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromJSONWithInvalidFormatTest()
        {
            RunTestForFileWithName(@"Resources\JSONWithInvalidFormat.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromJSONWithInvalidFieldTest()
        {
            RunTestForFileWithName(@"Resources\InvalidFieldOnJSON.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromJSONWithInvalidFieldValueParsingErrorTest()
        {
            RunTestForFileWithName(@"Resources\InvalidFieldValueOnJSON.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromJSONWithInvalidFieldValueForVehicleTest()
        {
            RunTestForFileWithName(@"Resources\JSONWithInvalidValueForVehicle.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromNonTextFileInvalidTest()
        {
            RunTestForFileWithName(@"Resources\TestImage2.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesFromNonExistingFileInvalidTest()
        {
            RunTestForFileWithName("Wololo.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesNullDictionaryInputInvalidTest()
        {
            testingStrategy.GetVehicles(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void JSONCISGetVehiclesNullPathInvalidTest()
        {
            RunTestForFileWithName(null);
        }

        private static IEnumerable<Vehicle> RunTestForFileWithName(string fileName)
        {
            string xmlTestFilePath = testFileLocation + fileName;
            var parameters = new Dictionary<string, object>() {
                { "Ubicación del archivo", xmlTestFilePath }
            };
            return testingStrategy.GetVehicles(parameters);
        }
    }
}