using Domain;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(0, testingVehicle.Id);
            Assert.AreEqual("Audi", testingVehicle.Brand);
            Assert.AreEqual("Q5", testingVehicle.Model);
            Assert.AreEqual(2016, testingVehicle.Year);
            Assert.AreEqual("Blue", testingVehicle.Color);
            Assert.AreEqual("QWERTYUI123456789", testingVehicle.VIN);
            Assert.AreEqual(VehicleType.CAR, testingVehicle.Type);
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
        public void VehicleSetInvalidVINEmptyTest()
        {
            testingVehicle.VIN = "";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINOnlySpacesTest()
        {
            testingVehicle.VIN = "   \n\n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINNullTest()
        {
            testingVehicle.VIN = null;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINPunctuationTest()
        {
            testingVehicle.VIN = "!@$#%^";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINLongerTest()
        {
            testingVehicle.VIN = "ASDFGHJKL123456789";
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleSetInvalidVINShorterTest()
        {
            testingVehicle.VIN = "ASDFGH12345";
        }

        [TestMethod]
        public void VehicleSetIdValidTest()
        {
            testingVehicle.Id = 42;
            Assert.AreEqual(42, testingVehicle.Id);
        }

        [TestMethod]
        public void VehicleParameterFactoryMethodValidTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                2016, "Green", "QWERTYUIO12345678");
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
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet1", "Onix",
                2016, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VehicleParameterFactoryMethodInvalidModelTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix!",
                2016, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidYearTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                2040, "Green", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidColorTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                2016, "Green#", "QWERTYUIO12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void UserParameterFactoryMethodInvalidVINTest()
        {
            testingVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                2016, "Green", "QWERTYUIO123");
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
            Assert.AreEqual(testingVehicleAsObject.GetHashCode(), testingVehicle.GetHashCode());
        }

        [TestMethod]
        public void UserToStringTest1()
        {
            Assert.AreEqual("QWERTYUI123456789. Audi Q5. 2016",
                testingVehicle.ToString());
        }

        [TestMethod]
        public void UserToStringTest2()
        {
            testingVehicle.VIN = "ZXCVBNM1234567890";
            testingVehicle.Brand = "Fiat";
            testingVehicle.Model = "1";
            testingVehicle.Year = 2017;
            Assert.AreEqual("ZXCVBNM1234567890. Fiat 1. 2017", testingVehicle.ToString());
        }
    }
}