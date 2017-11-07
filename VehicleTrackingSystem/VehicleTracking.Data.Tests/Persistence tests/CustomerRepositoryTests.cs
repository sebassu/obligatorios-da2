using System.Linq;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CustomerRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ICustomerRepository testingCustomerRepository;
        private static Customer testingCustomer;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingCustomerRepository = testingUnitOfWork.Customers;
            Assert.IsNotNull(testingCustomerRepository);
            testingCustomer = Customer.FromNamePhoneNumber("Marcos Mundstock",
                "099424242");
            AddNewCustomerAndSaveChanges(testingCustomer);
        }

        #region AddNewCustomer tests
        [TestMethod]
        public void CRepositoryAddNewCustomerValidTest()
        {
            var customerToAdd = Customer.InstanceForTestingPurposes();
            AddNewCustomerAndSaveChanges(customerToAdd);
            CollectionAssert.Contains(testingCustomerRepository
                .Elements.ToList(), customerToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void CRepositoryAddNullCustomerInvalidTest()
        {
            AddNewCustomerAndSaveChanges(null);
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void CRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedCustomer = Customer.InstanceForTestingPurposes();
            AddNewCustomerAndSaveChanges(addedCustomer);
            var castRepostory = testingCustomerRepository as GenericRepository<Customer>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedCustomer));
        }

        [TestMethod]
        public void CRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedCustomer = Customer.InstanceForTestingPurposes();
            var castRepostory = testingCustomerRepository as GenericRepository<Customer>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedCustomer));
        }
        #endregion

        #region IfExistsGetCustomerWithData tests
        [TestMethod]
        public void CRepositoryIfExistsGetCustomerWithDataReturnsElementTest()
        {
            var result = testingCustomerRepository.IfExistsGetCustomerWithData(testingCustomer.Name,
                testingCustomer.PhoneNumber);
            Assert.AreEqual(testingCustomer, result);
        }

        [TestMethod]
        public void CRepositoryIfExistsGetCustomerWithDataDifferentNamesReturnsNullTest()
        {
            var result = testingCustomerRepository.IfExistsGetCustomerWithData("Wololo",
                testingCustomer.PhoneNumber);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CRepositoryIfExistsGetCustomerWithDataDifferentPhoneNumbersReturnsNullTest()
        {
            var result = testingCustomerRepository.IfExistsGetCustomerWithData(testingCustomer.Name,
                null);
            Assert.IsNull(result);
        }
        #endregion

        private static void AddNewCustomerAndSaveChanges(Customer customerToAdd)
        {
            testingCustomerRepository.AddNewCustomer(customerToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}