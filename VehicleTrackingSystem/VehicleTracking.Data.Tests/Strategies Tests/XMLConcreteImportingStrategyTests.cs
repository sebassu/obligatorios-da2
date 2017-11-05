﻿using Domain;
using System;
using System.IO;
using System.Linq;
using ImportingStrategies;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Strategies_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class XMLConcreteImportingStrategyTests
    {
        private static IImportingStrategy testingStrategy;
        private static string testFileLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + @"\";
        private static readonly IEnumerable<Vehicle> expectedVehicles =
            new List<Vehicle>()
            {
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1981, "Red", "RUSH2112MVNGPICRS"),
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Renault",
                "Kangoo", 2001, "Gris claro", "ASNDJFU1258741SMD")
            }.AsReadOnly();

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingStrategy = new XMLConcreteImportingStrategy();
        }

        [TestMethod]
        public void XMLCISGetRequiredParametersTest()
        {
            var expectedResult = new Dictionary<string, Type>() {
                { "Ubicación del archivo", typeof(Path) }
            };
            var obtainedResult = testingStrategy.RequiredParameters;
            CollectionAssert.AreEqual(expectedResult,
                obtainedResult);
        }

        [TestMethod]
        public void XMLCISGetVehiclesFromXMLTestFileValidTest()
        {
            var obtainedResult =
                RunTestForFileWithName("VehicleXMLImportingTestFile.xml");
            CollectionAssert.AreEqual(expectedVehicles.ToList(),
                obtainedResult.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesFromNonXMLTestFileInvalidTest()
        {
            RunTestForFileWithName("VehicleJSONImportingTestFile.json");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesUndefinedRequiredParameterInvalidTest()
        {
            var parameters = new Dictionary<string, object>();
            testingStrategy.GetVehicles(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesNullDictionaryInputInvalidTest()
        {
            testingStrategy.GetVehicles(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesWithInvalidVehicleTypeTest()
        {
            RunTestForFileWithName(@"Resources\InvalidVehicleType.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesWithInvalidXMLSchemaTypeTest()
        {
            RunTestForFileWithName(@"Resources\InvalidXMLSchema.xml");
        }

        [TestMethod]
        [ExpectedException(typeof(ImportingException))]
        public void XMLCISGetVehiclesFromNonExistingFileInvalidTest()
        {
            RunTestForFileWithName("Wololo.xml");
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