using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Data.Tests.Domain_tests
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
        public void VehicleForTestingPurposesTest()
        {
            Assert.AreEqual("Audi", testingVehicle.Brand);
            Assert.AreEqual("Q5", testingVehicle.Model);
            Assert.AreEqual(2016, testingVehicle.Year);
        }

        //Vehicle Brand
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
            testingVehicle.Brand = "     ";
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

        //Vehicle model
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
            testingVehicle.Model = "     ";
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

        //Vehicle Year
        [TestMethod]//no funciona
        public void VehicleSetValidYearTest()
        {
            testingVehicle.Year = 2017;
            Assert.AreEqual(2017, testingVehicle.Year);
            //Assert.AreSame(2017, testingVehicle.Year);
            //Assert.IsTrue(2017 == testingVehicle.Year);
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
    }
}
