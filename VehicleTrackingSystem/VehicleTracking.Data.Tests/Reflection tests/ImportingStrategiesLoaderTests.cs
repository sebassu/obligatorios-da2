using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking.Reflection;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Reflection_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ImportingStrategiesLoaderTests
    {
        private static string testFileLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName +
            @"\Resources\TestingImportingStrategies\";
        private static IEnumerable<IImportingStrategy> result;
        private static readonly Dictionary<string, Type> expectedParameters =
            new Dictionary<string, Type>() {
                { "Parámetro",typeof(string) }
            };
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
            result = ImportingStrategiesLoader.FromDllFilePath(testFileLocation
                + "TestingImportingStrategies.dll");
        }

        [TestMethod]
        public void IStrategiesLoaderFromDllFilePathIsNotNullTest()
        {
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IStrategiesLoaderFromDllFilePathHasExpectedTypesTest()
        {
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void IStrategiesLoaderFromDllFilePathHasExpectedTestingStrategy1Test()
        {
            var firstStrategy = result.First();
            CollectionAssert.AreEqual(new Dictionary<string, Type>(),
                firstStrategy.RequiredParameters);
            CollectionAssert.AreEqual(expectedVehicles.ToList(),
                firstStrategy.GetVehicles(null).ToList());
        }

        [TestMethod]
        public void IStrategiesLoaderFromDllFilePathHasExpectedTestingStrategy2Test()
        {
            var firstStrategy = result.Last();
            CollectionAssert.AreEqual(expectedParameters,
                firstStrategy.RequiredParameters);
            CollectionAssert.AreEqual(new List<Vehicle>(),
                firstStrategy.GetVehicles(null).ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ReflectionException))]
        public void IStrategiesLoaderFromInvalidDllFilePathTest()
        {
            ImportingStrategiesLoader.FromDllFilePath("Wololo.dll");
        }

        [TestMethod]
        [ExpectedException(typeof(ReflectionException))]
        public void IStrategiesLoaderFromNullDllFilePathTest()
        {
            ImportingStrategiesLoader.FromDllFilePath(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ReflectionException))]
        public void IStrategiesLoaderFromDllFilePathWithStrategyWithoutConstructorInvalidTest()
        {
            var result = ImportingStrategiesLoader.FromDllFilePath(testFileLocation +
                @"InvalidStrategy\StrategyWithNoPublicParameterlessConstructor.dll");
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void IStrategiesLoaderFromDllFilePathWithNoStrategiesValidTest()
        {
            var result = ImportingStrategiesLoader.FromDllFilePath(
                testFileLocation + "ProjectWithNoValidStrategies.dll");
            Assert.IsFalse(result.Any());
        }
    }
}