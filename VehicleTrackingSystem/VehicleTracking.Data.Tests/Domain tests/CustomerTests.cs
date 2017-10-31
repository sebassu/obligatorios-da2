using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    public class CustomerTests
    {
        private static Customer testingCustomer;

        [TestInitialize]
        public void TestSetup()
        {
            testingCustomer = Customer.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void CustomerInstanceForTestingPurposesTest()
        {
            Assert.AreEqual("Cliente inválido", testingCustomer.Name);
        }

        [TestMethod]
        public void CustomerSetValidNameTest()
        {
            testingCustomer.Name = "Marcos Mundstock";
            Assert.AreEqual("Marcos Mundstock", testingCustomer.Name);
        }

        [TestMethod]
        public void CustomerSetValidNameTrimTest()
        {
            testingCustomer.Name = "  Daniel Abraham Rabinovich  ";
            Assert.AreEqual("Daniel Abraham Rabinovich", testingCustomer.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidNameNumbersTest()
        {
            testingCustomer.Name = "123456789";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidNamePunctuationTest()
        {
            testingCustomer.Name = "!@.^^@& 19$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidNameOnlySpacesTest()
        {
            testingCustomer.Name = " \t\t  \t  \n \n\t ";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidNameEmptyTest()
        {
            testingCustomer.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidNameNullTest()
        {
            testingCustomer.Name = null;
        }
    }
}