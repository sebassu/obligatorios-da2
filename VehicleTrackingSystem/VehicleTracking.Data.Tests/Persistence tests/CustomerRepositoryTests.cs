using Domain;
using Persistence;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ICustomerRepository testingCustomerRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingCustomerRepository = testingUnitOfWork.Customers;
            Assert.IsNotNull(testingCustomerRepository);
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

        private void AddNewCustomerAndSaveChanges(Customer customerToAdd)
        {
            testingCustomerRepository.AddNewCustomer(customerToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}