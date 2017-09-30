using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class LotTests
    {
        private static Lot testingLot;

        [TestInitialize]
        public void TestSetup()
        {
            testingLot = Lot.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void LotInstanceForTestingPurposesTest()
        {
            Assert.AreEqual("Lote inválido", testingLot.Name);
            Assert.AreEqual("Descripción inválida", testingLot.Description);
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
            testingLot.Description = "     ";
        }

        [TestMethod]
        [ExpectedException(typeof(LotException))]
        public void LotSetInvalidDescriptionNullTest()
        {
            testingLot.Description = null;
        }
    }
}
