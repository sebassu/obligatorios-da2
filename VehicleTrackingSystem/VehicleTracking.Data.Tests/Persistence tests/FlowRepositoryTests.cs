using Domain;
using Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    public class FlowRepositoryTests
    {
        private static readonly UnitOfWork testingUnitOfWork
            = new UnitOfWork();
        private static IFlowRepository testingFlowRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingFlowRepository = testingUnitOfWork.Flow;
            Assert.IsNotNull(testingFlowRepository);
            Assert.AreEqual(VTSystemDatabaseInitializer.defaultFlow,
                testingFlowRepository.GetCurrentFlow());
        }

        #region RegisterNewFlow tests
        [TestMethod]
        public void CRepositoryAddNewFlowValidTest()
        {
            var flowToAdd = Flow.InstanceForTestingPurposes();
            RegisterNewFlowAndSaveChanges(flowToAdd);
            Assert.AreEqual(flowToAdd, testingFlowRepository
                .GetCurrentFlow());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void CRepositoryAddNullFlowInvalidTest()
        {
            RegisterNewFlowAndSaveChanges(null);
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void CRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedFlow = Flow.InstanceForTestingPurposes();
            RegisterNewFlowAndSaveChanges(addedFlow);
            var castRepostory = testingFlowRepository as GenericRepository<Flow>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedFlow));
        }

        [TestMethod]
        public void CRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedFlow = Flow.InstanceForTestingPurposes();
            var castRepostory = testingFlowRepository as GenericRepository<Flow>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedFlow));
        }
        #endregion

        private static void RegisterNewFlowAndSaveChanges(Flow flowToRegister)
        {
            testingFlowRepository.RegisterNewFlow(flowToRegister);
            testingUnitOfWork.SaveChanges();
        }
    }
}