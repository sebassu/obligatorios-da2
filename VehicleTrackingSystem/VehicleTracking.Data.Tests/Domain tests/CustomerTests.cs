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
            Assert.AreEqual("099424242", testingCustomer.PhoneNumber);
        }

        [TestMethod]
        public void CustomerSetIdValidTest()
        {
            testingCustomer.Id = 42;
            Assert.AreEqual(42, testingCustomer.Id);
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

        [TestMethod]
        public void CustomerSetValidPhoneNumberTest()
        {
            testingCustomer.PhoneNumber = "29024546";
            Assert.AreEqual("29024546", testingCustomer.PhoneNumber);
        }

        [TestMethod]
        public void CustomerSetValidPhoneNumberStartingWith0Test()
        {
            testingCustomer.PhoneNumber = "091946954";
            Assert.AreEqual("091946954", testingCustomer.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidPhoneNumberStartingWithDouble0Test()
        {
            testingCustomer.PhoneNumber = "00123456";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidPhoneNumberLettersTest()
        {
            testingCustomer.PhoneNumber = "QueTal987654";
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerSetInvalidPhoneNumberTooLongTest()
        {
            testingCustomer.PhoneNumber = "987654321123456789";
        }

        [TestMethod]
        public void CustomerParameterFactoryMethodValidTest()
        {
            testingCustomer = Customer.FromNamePhoneNumber("Mario Santos", "099424242");
            Assert.AreEqual("Mario Santos", testingCustomer.Name);
            Assert.AreEqual("099424242", testingCustomer.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerParameterFactoryMethodInvalidNameTest()
        {
            Customer.FromNamePhoneNumber("78#&$^%* ))_==798/*", "099424242");
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerException))]
        public void CustomerParameterFactoryMethodInvalidPhoneNumberTest()
        {
            Customer.FromNamePhoneNumber("Mario Santos", null);
        }

        [TestMethod]
        public void CustomerEqualsReflexiveTest()
        {
            Assert.AreEqual(testingCustomer, testingCustomer);
        }

        [TestMethod]
        public void CustomerEqualsSymmetricTest()
        {
            Customer secondTestingCustomer = Customer.InstanceForTestingPurposes();
            Assert.AreEqual(testingCustomer, secondTestingCustomer);
            Assert.AreEqual(secondTestingCustomer, testingCustomer);
        }

        [TestMethod]
        public void CustomerEqualsTransitiveTest()
        {
            testingCustomer = Customer.FromNamePhoneNumber("Same name", "099212121");
            Customer secondTestingCustomer = Customer.FromNamePhoneNumber("Same name", "099212121");
            Customer thirdTestingCustomer = Customer.FromNamePhoneNumber("Same name", "099212121");
            Assert.AreEqual(testingCustomer, secondTestingCustomer);
            Assert.AreEqual(secondTestingCustomer, thirdTestingCustomer);
            Assert.AreEqual(testingCustomer, thirdTestingCustomer);
        }

        [TestMethod]
        public void CustomerEqualsDifferentCustomerNamesTest()
        {
            testingCustomer = Customer.FromNamePhoneNumber("Some name", "099212121");
            Customer secondTestingCustomer = Customer.FromNamePhoneNumber("Some other name",
                "099212121");
            Assert.AreNotEqual(testingCustomer, secondTestingCustomer);
        }

        [TestMethod]
        public void CustomerEqualsDifferentCustomerPhoneNumbersTest()
        {
            testingCustomer = Customer.FromNamePhoneNumber("Same name", "099212121");
            Customer secondTestingCustomer = Customer.FromNamePhoneNumber("Same name",
                "099424242");
            Assert.AreNotEqual(testingCustomer, secondTestingCustomer);
        }

        [TestMethod]
        public void CustomerEqualsNullTest()
        {
            Assert.AreNotEqual(testingCustomer, null);
        }

        [TestMethod]
        public void CustomerEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingCustomer, someRandomObject);
        }

        [TestMethod]
        public void CustomerGetHashCodeTest()
        {
            object testingCustomerAsObject = testingCustomer;
            Assert.AreEqual(testingCustomerAsObject.GetHashCode(),
                testingCustomer.GetHashCode());
        }
    }
}