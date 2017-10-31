using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    public class SaleTests
    {
        private static Sale testingSale;

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
    }
}