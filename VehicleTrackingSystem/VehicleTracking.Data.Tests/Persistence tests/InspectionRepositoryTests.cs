using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InspectionRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IInspectionRepository testingInspectionRepository;
        private static readonly User testingCreator = User.CreateNewUser(UserRoles.PORT_OPERATOR,
            "Emilio", "Ravenna", "eRavenna", "HablarUnasPalabritas", "099212121");

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingInspectionRepository = testingUnitOfWork.Inspections;
            Assert.IsNotNull(testingInspectionRepository);
        }

        #region AddNewLot tests
        [TestMethod]
        public void IRepositoryAddNewInspectionValidTest()
        {
            Inspection inspectionToVerify = GetNewValidTestingInspection();
            AddNewInspectionAndSaveChanges(inspectionToVerify);
            CollectionAssert.Contains(testingInspectionRepository.Elements.ToList(),
                inspectionToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void IRepositoryAddNullInspectionInvalidTest()
        {
            AddNewInspectionAndSaveChanges(null);
        }
        #endregion

        #region GetInspectionWithId tests
        [TestMethod]
        public void IRepositoryGetInspectionWithIdValidTest()
        {
            Inspection inspectionToVerify = GetNewValidTestingInspection();
            AddNewInspectionAndSaveChanges(inspectionToVerify);
            Inspection result = testingInspectionRepository
                .GetInspectionWithId(inspectionToVerify.Id);
            Assert.AreEqual(inspectionToVerify, result);
        }

        [TestMethod]
        public void IRepositoryGetInspectionWithIdAdditionalFieldsAccessValidTest()
        {
            Inspection inspectionToVerify = GetNewValidTestingInspection();
            inspectionToVerify.Damages = new List<Damage>() {
                Damage.InstanceForTestingPurposes() };
            AddNewInspectionAndSaveChanges(inspectionToVerify);
            Inspection result = testingInspectionRepository
                .GetInspectionWithId(inspectionToVerify.Id);
            Assert.AreEqual(inspectionToVerify.Responsible,
                result.Responsible);
            Assert.AreEqual(inspectionToVerify.Location, result.Location);
            CollectionAssert.AreEqual(inspectionToVerify.Damages.ToList(),
                result.Damages.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void IRepositoryGetInspectionWithNonExistentIdInvalidTest()
        {
            testingInspectionRepository.GetInspectionWithId(Guid.NewGuid());
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void IRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedInspection = GetNewValidTestingInspection();
            AddNewInspectionAndSaveChanges(addedInspection);
            var castRepostory = testingInspectionRepository as GenericRepository<Inspection>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedInspection));
        }

        [TestMethod]
        public void IRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedInspection = Inspection.InstanceForTestingPurposes();
            var castRepostory = testingInspectionRepository as GenericRepository<Inspection>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedInspection));
        }
        #endregion

        private static Inspection GetNewValidTestingInspection()
        {
            var location = testingUnitOfWork.Locations.Ports.First();
            var testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            var inspectionToAdd = Inspection.CreateNewInspection(testingCreator, location,
                DateTime.Now, new List<Damage>(), testingVehicle);
            testingVehicle.PortInspection = inspectionToAdd;
            testingUnitOfWork.Vehicles.AddNewVehicle(testingVehicle);
            return inspectionToAdd;
        }

        private static void AddNewInspectionAndSaveChanges(Inspection
            inspectionToAdd)
        {
            testingInspectionRepository.AddNewInspection(inspectionToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}