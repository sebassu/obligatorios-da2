using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleTests
    {
        private static Vehicle testingVehicle;

        [TestInitialize]
        public void TestSetup()
        {
            testingVehicle = Vehicle.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void VehicleInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingVehicle.Id);
            Assert.AreEqual("Marca inválida", testingVehicle.Brand);
            Assert.AreEqual("Vehículo inválido", testingVehicle.Model);
            Assert.AreEqual(1912, testingVehicle.Year);
            Assert.AreEqual("Color inválido", testingVehicle.Color);
            Assert.AreEqual("VININVLDOVNINVLDO", testingVehicle.VIN);
            Assert.AreEqual(VehicleType.CAR, testingVehicle.Type);
        }

        [TestMethod]
        public void VehicleSetIdValidTest()
        {
            testingVehicle.Id = 42;
            Assert.AreEqual(42, testingVehicle.Id);
        }

        [TestMethod]
        public void VehicleSetValidBrandTest()
        {
            testingVehicle.Brand = "Fiat";
            Assert.AreEqual("Fiat", testingVehicle.Brand);
        }

        [TestMethod]
        public void VehicleSetValidBrandCompoundTest()
        {
            testingVehicle.Brand = "  Mercedes Benz ";
            Assert.AreEqual("Mercedes Benz", testingVehicle.Brand);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidBrandNumbersTest()
        {
            testingVehicle.Brand = "123";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidBrandEmptyTest()
        {
            testingVehicle.Brand = "";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidBrandOnlySpacesTest()
        {
            testingVehicle.Brand = " \n\n\n   \t ";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidBrandNullTest()
        {
            testingVehicle.Brand = null;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidBrandPunctuationTest()
        {
            testingVehicle.Brand = "!@$#%^";
        }

        [TestMethod]
        public void VehicleSetValidModelTest()
        {
            testingVehicle.Model = "R8";
            Assert.AreEqual("R8", testingVehicle.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidModelEmptyTest()
        {
            testingVehicle.Model = "";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidModelOnlySpacesTest()
        {
            testingVehicle.Model = " \t\t  \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidModelNullTest()
        {
            testingVehicle.Model = null;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidModelPunctuationTest()
        {
            testingVehicle.Model = "!@$#%^";
        }

        [TestMethod]
        public void VehicleSetValidYearTest()
        {
            testingVehicle.Year = 2017;
            Assert.AreEqual(2017, testingVehicle.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidYearGreaterThanNowTest()
        {
            testingVehicle.Year = 2022;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidYearLessThan1900Test()
        {
            testingVehicle.Year = 1500;
        }

        [TestMethod]
        public void VehicleSetValidColorTest()
        {
            testingVehicle.Color = "Blue";
            Assert.AreEqual("Blue", testingVehicle.Color);
        }

        [TestMethod]
        public void VehicleSetValidColorCompoundTest()
        {
            testingVehicle.Color = "  Dark Red ";
            Assert.AreEqual("Dark Red", testingVehicle.Color);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidColorNumberTest()
        {
            testingVehicle.Color = "123";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidColorEmptyTest()
        {
            testingVehicle.Color = "";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidColorOnlySpacesTest()
        {
            testingVehicle.Color = "     ";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidColorNullTest()
        {
            testingVehicle.Color = null;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidColorPunctuationTest()
        {
            testingVehicle.Color = "!@$#%^";
        }

        [TestMethod]
        public void VehicleSetVINValidTest()
        {
            testingVehicle.VIN = "12345678ASDFGHJKL";
            Assert.AreEqual("12345678ASDFGHJKL", testingVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINTooLongTest()
        {
            testingVehicle.VIN = "ASDFGHJKL123456789";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINTooShortTest()
        {
            testingVehicle.VIN = "ASDFGH12345";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINPunctuationTest()
        {
            testingVehicle.VIN = "!@$#%@ @(*# ^";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINSpacesTest()
        {
            testingVehicle.VIN = " \n\t    \t\n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINEmptyTest()
        {
            testingVehicle.VIN = "";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINNullTest()
        {
            testingVehicle.VIN = null;
        }

        [TestMethod]
        public void VehicleParameterFactoryMethodValidTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet", "Onix", 2016, "Green", "QWERTYUIO12345678");
            Assert.AreEqual(0, testingVehicle.Id);
            Assert.AreEqual(VehicleType.SUV, testingVehicle.Type);
            Assert.AreEqual("Chevrolet", testingVehicle.Brand);
            Assert.AreEqual("Onix", testingVehicle.Model);
            Assert.AreEqual(2016, testingVehicle.Year);
            Assert.AreEqual("Green", testingVehicle.Color);
            Assert.AreEqual("QWERTYUIO12345678", testingVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleParameterFactoryMethodInvalidBrandTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet1", "Onix", 2016, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleParameterFactoryMethodInvalidModelTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet", "Onix!", 2016, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidYearTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet", "Onix", 2040, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidColorTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet", "Onix", 2016, "Green#", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidVINTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV,
                "Chevrolet", "Onix", 2016, "Green", "QWERTYUIO123");
        }

        [TestMethod]
        public void VehicleEqualsNullTest()
        {
            Assert.AreNotEqual(testingVehicle, null);
        }

        [TestMethod]
        public void VehicleEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingVehicle, someRandomObject);
        }

        [TestMethod]
        public void VehicleEqualsReflexiveTest()
        {
            Assert.AreEqual(testingVehicle, testingVehicle);
        }

        [TestMethod]
        public void VehicleEqualsSymmetricTest()
        {
            Vehicle secondTestingVehicle = Vehicle.InstanceForTestingPurposes();
            Assert.AreEqual(testingVehicle, secondTestingVehicle);
            Assert.AreEqual(secondTestingVehicle, testingVehicle);
        }

        [TestMethod]
        public void UserGetHashCodeTest()
        {
            object testingVehicleAsObject = testingVehicle;
            Assert.AreEqual(testingVehicleAsObject.GetHashCode(),
                testingVehicle.GetHashCode());
        }

        [TestMethod]
        public void VehicleToStringTest1()
        {
            Assert.AreEqual("VININVLDOVNINVLDO. Marca inválida " +
                "Vehículo inválido. 1912", testingVehicle.ToString());
        }

        [TestMethod]
        public void VehicleToStringTest2()
        {
            testingVehicle.VIN = "ZXCVBNM1234567890";
            testingVehicle.Brand = "Fiat";
            testingVehicle.Model = "1";
            testingVehicle.Year = 2017;
            Assert.AreEqual("ZXCVBNM1234567890. Fiat 1. 2017",
                testingVehicle.ToString());
        }

        [TestMethod]
        public void VehicleGetPortLotValidTest()
        {
            Assert.AreSame(testingVehicle.StagesData.PortLot,
                testingVehicle.PortLot);
        }

        [TestMethod]
        public void VehicleGetPortInspectionValidTest()
        {
            Assert.AreSame(testingVehicle.StagesData.PortInspection,
                testingVehicle.PortInspection);
        }

        [TestMethod]
        public void VehicleGetTransportDataValidTest()
        {
            Assert.AreSame(testingVehicle.StagesData.TransportData,
                testingVehicle.TransportData);
        }

        [TestMethod]
        public void VehicleGetYardInspectionValidTest()
        {
            Assert.AreSame(testingVehicle.StagesData.YardInspection,
                testingVehicle.YardInspection);
        }

        [TestMethod]
        public void VehicleGetYardMovementsValidTest()
        {
            Assert.AreSame(testingVehicle.StagesData.YardMovements,
                testingVehicle.Movements);
        }

        [TestMethod]
        public void VehicleSetYardInspectionValidTest()
        {
            Inspection inspectionToSet = GetValidYardInspectionForTestingVehicle();
            PromoteTestingVehicleToYardStage();
            testingVehicle.YardInspection = inspectionToSet;
            Assert.AreSame(inspectionToSet, testingVehicle.YardInspection);
        }

        [TestMethod]
        public void VehicleRegisterNewMovementToSubzoneValidTest()
        {
            var inspectionToSet = GetValidYardInspectionForTestingVehicle();
            PromoteTestingVehicleToYardStage();
            testingVehicle.YardInspection = inspectionToSet;
            Movement result = testingVehicle.RegisterNewMovementToSubzone(
                User.InstanceForTestingPurposes(), DateTime.Now,
                Subzone.InstanceForTestingPurposes());
            CollectionAssert.Contains(testingVehicle.Movements.ToList(), result);
        }

        private static void PromoteTestingVehicleToYardStage()
        {
            var fakeProcessData = new ProcessData
            {
                CurrentStage = ProcessStages.YARD,
                Inspections = new List<Inspection>() {
                    Inspection.InstanceForTestingPurposes() }
            };
            testingVehicle.StagesData = fakeProcessData;
        }

        private static Inspection GetValidYardInspectionForTestingVehicle()
        {
            Location someYard = Location.CreateNewLocation(LocationType.YARD,
                "Scotland Yard");
            Inspection result = Inspection.CreateNewInspection(User.InstanceForTestingPurposes(),
                someYard, DateTime.Now, new List<Damage>(), testingVehicle);
            return result;
        }
    }
}