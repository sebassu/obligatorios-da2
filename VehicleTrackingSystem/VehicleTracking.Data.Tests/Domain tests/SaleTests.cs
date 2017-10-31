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
    }
}