using Domain;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    public class SaleTests
    {
        private static Sale testingSale;
        private static Vehicle testingVehicleForSale;
        private static Customer testingBuyer;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingBuyer = Customer.InstanceForTestingPurposes();
            testingVehicleForSale = Vehicle.InstanceForTestingPurposes();
            testingVehicleForSale.IsReadyForSale = true;
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingSale = Sale.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void SaleInstanceForTestingPurposesTest()
        {
            Assert.IsNull(testingSale.Buyer);
        }

        [TestMethod]
        public void SaleSetBuyerValidTest()
        {
            var buyerToSet = Customer.InstanceForTestingPurposes();
            testingSale.Buyer = buyerToSet;
            Assert.AreSame(buyerToSet, testingSale.Buyer);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetNullBuyerInvalidTest()
        {
            testingSale.Buyer = null;
        }

        [TestMethod]
        public void SaleSetSellingPriceValidTest()
        {
            testingSale.SellingPrice = 1812;
            Assert.AreEqual(1812, testingSale.SellingPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetZeroSellingPriceInvalidTest()
        {
            testingSale.SellingPrice = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetNegativeSellingPriceInvalidTest()
        {
            testingSale.SellingPrice = -2112;
        }

        [TestMethod]
        public void SaleSetValidVehicleVINTest()
        {
            testingSale.VehicleVIN = "RUSH2112RLLTHEBNS";
            Assert.AreEqual("RUSH2112RLLTHEBNS", testingSale.VehicleVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidVehicleVINTooShortTest()
        {
            testingSale.VehicleVIN = "QWERT12345";
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidVehicleVINTooLongTest()
        {
            testingSale.VehicleVIN = "QWERTY1234567890QWERTY";
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidVehicleVINPunctuationTest()
        {
            testingSale.VehicleVIN = "09&,. #%$*%%@!!--**//";
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidVehicleVINSpacesTest()
        {
            testingSale.VehicleVIN = "  \n   \n\t\t \n   ";
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidVehicleVINEmptyTest()
        {
            testingSale.VehicleVIN = "";
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetNullVehicleVINInvalidTest()
        {
            testingSale.VehicleVIN = null;
        }

        [TestMethod]
        public void SaleSetValidDateTimeTest()
        {
            testingSale.DateTime = DateTime.Today;
            Assert.AreEqual(DateTime.Today, testingSale.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidFutureDateTest()
        {
            testingSale.DateTime = new DateTime(2112, 12, 24, 3, 40, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleSetInvalidFarPastDateTimeTest()
        {
            testingSale.DateTime = new DateTime(1812, 3, 12, 12, 33, 58);
        }

        [TestMethod]
        public void SaleParameterFactoryMethodValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingSale = Sale.FromBuyerVehiclePriceDateTime(testingBuyer,
                testingVehicleForSale, 2112, dateTimeToSet);
            Assert.AreSame(testingBuyer, testingSale.Buyer);
            Assert.AreEqual(testingVehicleForSale.VIN, testingSale.VehicleVIN);
            Assert.AreEqual(2112, testingSale.SellingPrice);
            Assert.AreEqual(dateTimeToSet, testingSale.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodInvalidBuyerTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(null, testingVehicleForSale,
                2112, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodNullVehicleInvalidTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, null, 2112,
                DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodVehicleNotReadyForSaleInvalidTest()
        {
            var notReadyVehicle = Vehicle.InstanceForTestingPurposes();
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, notReadyVehicle, 2112,
                DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodVehicleZeroPriceInvalidTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, testingVehicleForSale,
                0, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodVehicleNegativePriceInvalidTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, testingVehicleForSale,
                -1812, DateTime.Today);
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodVehicleFutureDateInvalidTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, testingVehicleForSale,
                5500, new DateTime(2112, 3, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(SaleException))]
        public void SaleParameterFactoryMethodVehicleFarPastDateInvalidTest()
        {
            Sale.FromBuyerVehiclePriceDateTime(testingBuyer, testingVehicleForSale,
                5500, new DateTime(1812, 12, 24));
        }
    }
}