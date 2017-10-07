using Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Persistence;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LotRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ILotRepository testingLotRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingLotRepository = testingUnitOfWork.Lots;
        }

        [TestMethod]
        public void LRepositoryAddNewLotValidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 1", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            CollectionAssert.Contains(testingLotRepository.Elements.ToList(), lotToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryAddNullLotInvalidTest()
        {
            AddNewLotAndSaveChanges(null);
        }

        private static void AddNewLotAndSaveChanges(Lot lotToAdd)
        {
            testingLotRepository.AddNewLot(lotToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}
