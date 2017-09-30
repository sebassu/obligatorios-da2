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
    public class SubzoneTests
    {
        private static Subzone testingSubzone;

        [TestInitialize]
        public void TestSetup()
        {
            testingSubzone = Subzone.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void SubzoneForTestingPurposesTest()
        {
            Assert.AreEqual("Subzone 1", testingSubzone.Name);
            Assert.AreEqual(3, testingSubzone.Capacity);
        }

        [TestMethod]
        public void SubzoneSetValidNameTest()
        {
            testingSubzone.Name = "A subzone";
            Assert.AreEqual("A subzone", testingSubzone.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameOnlyNumbersTest()
        {
            testingSubzone.Name = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNamePunctuationTest()
        {
            testingSubzone.Name = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameOnlySpacesTest()
        {
            testingSubzone.Name = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameEmptyTest()
        {
            testingSubzone.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void ZoneSetInvalidNameNullTest()
        {
            testingSubzone.Name = null;
        }

        [TestMethod]
        public void SubzoneSetValidCapacityTest()
        {
            testingSubzone.Capacity = 20;
            Assert.AreEqual(20, testingSubzone.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidCapacityLessThanMinimumTest()
        {
            testingSubzone.Capacity = 0;
        }
    }
}
