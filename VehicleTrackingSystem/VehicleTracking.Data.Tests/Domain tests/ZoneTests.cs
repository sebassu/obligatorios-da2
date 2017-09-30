﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneTests
    {
        private static Zone testingZone;

        [TestInitialize]
        public void TestSetup()
        {
            testingZone = Zone.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ZoneForTestingPurposesTest()
        {
            Assert.AreEqual("Zone 1", testingZone.Name);
        }

        [TestMethod]
        public void ZoneSetValidNameTest()
        {
            testingZone.Name = "A zone";
            Assert.AreEqual("A zone", testingZone.Name);
        }

        [TestMethod]
        public void ZoneSetValidNameCompoundTest()
        {
            testingZone.Name = "  Some zone  ";
            Assert.AreEqual("Some zone", testingZone.Name);
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
            testingZone.NAme = null;
        }
    }
}
