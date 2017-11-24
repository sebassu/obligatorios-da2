using System.Linq;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SaleRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork
            = new UnitOfWork();
        private static ISaleRepository testingSaleRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingSaleRepository = testingUnitOfWork.Sales;
            Assert.IsNotNull(testingSaleRepository);
        }

        #region AddNewSale tests
        [TestMethod]
        public void SRepositoryAddNewSaleValidTest()
        {
            var saleToAdd = Sale.InstanceForTestingPurposes();
            AddNewSaleAndSaveChanges(saleToAdd);
            CollectionAssert.Contains(testingSaleRepository.Elements.ToList(),
                saleToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SRepositoryAddNullSaleInvalidTest()
        {
            AddNewSaleAndSaveChanges(null);
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void SRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedSale = Sale.InstanceForTestingPurposes();
            AddNewSaleAndSaveChanges(addedSale);
            var castRepostory = testingSaleRepository as GenericRepository<Sale>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedSale));
        }

        [TestMethod]
        public void SRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedSale = Sale.InstanceForTestingPurposes();
            var castRepostory = testingSaleRepository as GenericRepository<Sale>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedSale));
        }
        #endregion

        private void AddNewSaleAndSaveChanges(Sale saleToAdd)
        {
            testingSaleRepository.AddNewSale(saleToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}