using System;
using Domain;
using Persistence;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    public class TransportRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ITransportRepository testingTransportRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingTransportRepository = testingUnitOfWork.Transports;
            Assert.IsNotNull(testingTransportRepository);
        }

        #region AddNewLot tests
        [TestMethod]
        public void TRepositoryAddNewTransportValidTest()
        {
            Transport transportToVerify = Transport.InstanceForTestingPurposes();
            AddNewTransportAndSaveChanges(transportToVerify);
            CollectionAssert.Contains(testingTransportRepository
                .Elements.ToList(), transportToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryAddNullTransportInvalidTest()
        {
            AddNewTransportAndSaveChanges(null);
        }
        #endregion

        #region UpdateTransport tests
        [TestMethod]
        public void TRepositoryUpdateLotValidTest()
        {
            var startDateToSet = new DateTime(1912, 1, 1);
            var endDateToSet = new DateTime(2000, 9, 9);
            var transportToVerify = Transport.InstanceForTestingPurposes();
            AddNewTransportAndSaveChanges(transportToVerify);
            transportToVerify.StartDateTime = startDateToSet;
            transportToVerify.FinalizeTransportOnDate(endDateToSet);
            UpdateTransportAndSaveChanges(transportToVerify);
            Assert.AreEqual(startDateToSet, transportToVerify.StartDateTime);
            Assert.AreEqual(endDateToSet, transportToVerify.EndDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyNullTransportInvalidTest()
        {
            UpdateTransportAndSaveChanges(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryModifyUnaddedTransportInvalidTest()
        {
            var unaddedTransport = Transport.InstanceForTestingPurposes();
            UpdateTransportAndSaveChanges(unaddedTransport);
        }
        #endregion

        #region GetTransportWithId tests
        [TestMethod]
        public void TRepositoryGetTransportWithIdValidTest()
        {
            var transportToVerify = Transport.InstanceForTestingPurposes();
            AddNewTransportAndSaveChanges(transportToVerify);
            var result = testingTransportRepository.GetTransportWithId(transportToVerify.Id);
            Assert.AreEqual(transportToVerify, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TRepositoryGetTransportWithUnregisteredIdInvalidTest()
        {
            testingTransportRepository.GetTransportWithId(9999);
        }
        #endregion

        private static void AddNewTransportAndSaveChanges(Transport transportToAdd)
        {
            testingTransportRepository.AddNewTransport(transportToAdd);
            testingUnitOfWork.SaveChanges();
        }

        private void UpdateTransportAndSaveChanges(Transport transportToUpdate)
        {
            testingTransportRepository.UpdateTransport(transportToUpdate);
            testingUnitOfWork.SaveChanges();
        }
    }
}