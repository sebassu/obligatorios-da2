using System;
using Domain;
using Persistence;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    public class InspectionRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IInspectionRepository testingInspectionRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingInspectionRepository = testingUnitOfWork.Inspections;
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
            Assert.AreEqual(inspectionToVerify.ResponsibleUser,
                result.ResponsibleUser);
            Assert.AreEqual(inspectionToVerify.Location, result.Location);
            CollectionAssert.AreEqual(inspectionToVerify.Damages.ToList(),
                result.Damages.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void IRepositoryGetInspectionWithNonExistentIdInvalidTest()
        {
            testingInspectionRepository.GetInspectionWithId(42);
        }
        #endregion

        private static Inspection GetNewValidTestingInspection()
        {
            User creator = User.InstanceForTestingPurposes();
            var location = testingUnitOfWork.Locations.Elements.First();
            var testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            var inspectionToAdd = Inspection.CreateNewInspection(creator, location,
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