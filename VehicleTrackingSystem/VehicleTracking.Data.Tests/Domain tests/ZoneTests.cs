using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneTests
    {
        private static Zone testingZone;
        private static List<Zone> subzoneList;
        private static Zone testingSubzone;

        [TestInitialize]
        public void TestSetup()
        {
            testingZone = Zone.InstanceForTestingPurposes();
            testingSubzone = Damage.SubzoneForTestingPurposes();
            subzoneList = new List<Zone> { testingSubzone };
        }

        [TestMethod]
        public void ZoneForTestingPurposesTest()
        {
            Assert.AreEqual("Zone 1", testingZone.Name);
        }

        [TestMethod]
        public void SubzoneForTestingPurposesTest()
        {
            Assert.AreEqual("Subzone 1", testingSubzone.Name);
        }

        [TestMethod]
        public void ZoneSetValidNameTest()
        {
            testingZone.Name = "A zone";
            Assert.AreEqual("A zone", testingZone.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameOnlyNumbersTest()
        {
            testingZone.Name = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNamePunctuationTest()
        {
            testingZone.Name = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameOnlySpacesTest()
        {
            testingZone.Name = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameEmptyTest()
        {
            testingZone.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameNullTest()
        {
            testingZone.Name = null;
        }

        [TestMethod]
        public void ZoneSetValidSubzoneListTest()
        {
            testingZone.Subzones = subzoneList;
            Assert.IsTrue(testingZone.Subzones.SequenceEqual(subzoneList));
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidSubzoneListEmptyTest()
        {
            testingZone.Subzones = new List<Zone>();
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidSubzoneListNullTest()
        {
            testingZone.Subzones = null;
        }
    }
}
