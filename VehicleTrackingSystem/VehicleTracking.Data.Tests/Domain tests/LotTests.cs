using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LotTests
    {
        private static Lot testingLot;
        private static readonly User testingCreator = User.InstanceForTestingPurposes();
        private static readonly ICollection<Vehicle> testingVehicles = new List<Vehicle>(
            new Vehicle[] {
                Vehicle.InstanceForTestingPurposes()
            });

        [TestInitialize]
        public void TestSetup()
        {
            testingLot = Lot.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void LotSetIdValidTest()
        {
            var idToSet = Guid.NewGuid();
            testingLot.Id = idToSet;
            Assert.AreEqual(idToSet, testingLot.Id);
        }

        [TestMethod]
        public void LotInstanceForTestingPurposesTest()
        {
            Assert.IsNull(testingLot.Creator);
            Assert.AreEqual("Lote inválido", testingLot.Name);
            Assert.AreEqual("Descripción inválida", testingLot.Description);
            Assert.IsFalse(testingLot.Vehicles.Any());
        }

        [TestMethod]
        public void LotSetValidNameTest()
        {
            testingLot.Name = "  El Lote de autos  ";
            Assert.AreEqual("El Lote de autos", testingLot.Name);
        }

        [TestMethod]
        public void LotSetValidNameWithNumbersTest()
        {
            testingLot.Name = "Lote12345";
            Assert.AreEqual("Lote12345", testingLot.Name);
        }

        [TestMethod]
        public void LotSetValidNameOnlyNumbersTest()
        {
            testingLot.Name = "9991010210";
            Assert.AreEqual("9991010210", testingLot.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidNamePunctuationTest()
        {
            testingLot.Name = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidNameOnlySpacesTest()
        {
            testingLot.Name = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidNameEmptyTest()
        {
            testingLot.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidNameNullTest()
        {
            testingLot.Name = null;
        }

        [TestMethod]
        public void LotSetValidDescriptionTest()
        {
            testingLot.Description = "Lote de nuevos ingresos a puerto.";
            Assert.AreEqual("Lote de nuevos ingresos a puerto.", testingLot.Description);
        }

        [TestMethod]
        public void LotSetValidDescriptionNumbersTest()
        {
            testingLot.Description = "134564654654";
            Assert.AreEqual("134564654654", testingLot.Description);
        }

        [TestMethod]
        public void LotSetValidDescriptionPunctuationTest()
        {
            testingLot.Description = "$/% --#$%&/!!-./";
            Assert.AreEqual("$/% --#$%&/!!-./", testingLot.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidDescriptionEmptyTest()
        {
            testingLot.Description = "";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidDescriptionOnlySpacesTest()
        {
            testingLot.Description = " \n  \n\t\n    ";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidDescriptionNullTest()
        {
            testingLot.Description = null;
        }

        [TestMethod]
        public void LotSetVehiclesMarksThemAsLottedTest()
        {
            Vehicle testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1984, "Red", "RUSH2112RLLTHEBNS");
            Vehicle[] vehiclesToAdd = new Vehicle[] { testingVehicle };
            testingLot.Vehicles = vehiclesToAdd;
            Assert.IsTrue(testingVehicle.IsLotted);
        }

        [TestMethod]
        public void LotSetVehiclesUnmarksThemAsLottedTest()
        {
            Vehicle vehicleToAddAndRemove = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1984, "Red", "RUSH2112RLLTHEBNS");
            Vehicle someOtherVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "DarkGray", "ASDFGHJKL12345678");
            testingLot.Vehicles = new Vehicle[] { vehicleToAddAndRemove };
            testingLot.Vehicles = new Vehicle[] { someOtherVehicle };
            Assert.IsFalse(vehicleToAddAndRemove.IsLotted);
        }

        [TestMethod]
        public void LotSetVehiclesAddingToLotAlreadyAddedVehicleValidTest()
        {
            Vehicle vehicle1 = Vehicle.CreateNewVehicle(VehicleType.SUV, "Renault",
                "SUVModel", 2001, "DarkGray", "ASMKDJE1224MAKIOP");
            Vehicle vehicle2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1984, "Red", "RUSH2112RLLTHEBNS");
            Vehicle vehicle3 = Vehicle.CreateNewVehicle(VehicleType.VAN, "Chevrolet", "Onix",
                2015, "Blue", "ASDFGHJKL12345678");
            testingLot.Vehicles = new Vehicle[] { vehicle1, vehicle2 };
            testingLot.Vehicles = new Vehicle[] { vehicle2, vehicle3 };
            Assert.IsFalse(vehicle1.IsLotted);
            Assert.IsTrue(vehicle2.IsLotted);
            Assert.IsTrue(vehicle3.IsLotted);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetVehiclesEmptyCollectionInvalidTest()
        {
            testingLot.Vehicles = new List<Vehicle>();
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetVehiclesNullVehicleCollectionInvalidTest()
        {
            testingLot.Vehicles = null;
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetVehiclesContainsVehicleOnOtherLotInvalidTest()
        {
            Vehicle testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1984, "Red", "RUSH2112RLLTHEBNS");
            testingLot.Vehicles = new Vehicle[] { testingVehicle };
            Lot someOtherLot = Lot.InstanceForTestingPurposes();
            someOtherLot.Vehicles = new Vehicle[] { testingVehicle };
        }

        [TestMethod]
        public void LotParameterFactoryMethodValidTest()
        {
            var vehiclesToAdd = new Vehicle[] {
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "DarkGray", "ASDFGHJKL12345678"),
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari", "Barchetta",
                1984, "Red", "RUSH2112RLLTHEBNS"),
            };
            Assert.AreEqual(UserRoles.ADMINISTRATOR, testingCreator.Role);
            testingLot = Lot.CreatorNameDescriptionVehicles(testingCreator,
                "Lote 1", "Buen lote.", vehiclesToAdd);
            Assert.AreEqual(testingCreator, testingLot.Creator);
            Assert.AreEqual("Lote 1", testingLot.Name);
            Assert.AreEqual("Buen lote.", testingLot.Description);
            CollectionAssert.AreEqual(vehiclesToAdd.ToList(), testingLot.Vehicles.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodInvalidNameTest()
        {
            testingLot = Lot.CreatorNameDescriptionVehicles(testingCreator,
                "^&^# 1-=+&#^", "Buen lote.", testingVehicles);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodInvalidDescriptionTest()
        {
            testingLot = Lot.CreatorNameDescriptionVehicles(testingCreator,
                "Lote 1", "\t\t\t\n  \t   \n", testingVehicles);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodNullCreatorTest()
        {
            testingLot = Lot.CreatorNameDescriptionVehicles(null,
                "Lote 2", "El lotecito.", testingVehicles);
        }

        [TestMethod]
        public void LotParameterFactoryMethodAuthorizedCreatorPortOperatorTest()
        {
            User creator = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099698869");
            testingLot = Lot.CreatorNameDescriptionVehicles(creator,
                "Lote 2", "El lotecito.", testingVehicles);
            Assert.AreEqual(creator, testingLot.Creator);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodUnauthorizedCreatorTransporterTest()
        {
            User creator = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne", "NoHaceFaltaSaleSolo", "099212121");
            testingLot = Lot.CreatorNameDescriptionVehicles(creator,
                "Lote X", "Cierto Lote.", testingVehicles);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodUnauthorizedCreatorYardOperatorTest()
        {
            User creator = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099698869");
            testingLot = Lot.CreatorNameDescriptionVehicles(creator,
                "Lote 2", "El lotecito.", testingVehicles);
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodEmptyVehicleCollectionTest()
        {
            testingLot = Lot.CreatorNameDescriptionVehicles(testingCreator,
                "Lote 3", "El lote tercero, lote número 3.", new List<Vehicle>());
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotParameterFactoryMethodNullVehicleCollectionTest()
        {
            testingLot = Lot.CreatorNameDescriptionVehicles(testingCreator,
                "Lote 3", "El lote tercero, lote número 3.", null);
        }

        [TestMethod]
        public void LotWasTransportedValidTest()
        {
            Assert.IsFalse(testingLot.WasTransported);
            testingLot.WasTransported = true;
            Assert.IsTrue(testingLot.WasTransported);
        }
    }
}