using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Domain_tests
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
    }
}