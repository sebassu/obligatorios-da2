﻿using System;
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
        private static List<Subzone> subzoneList;
        private static Zone testingZone;

        [TestInitialize]
        public void TestSetup()
        {
            testingSubzone = Subzone.InstanceForTestingPurposes();
            subzoneList = new List<Subzone> { testingSubzone };
            testingZone = Zone.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void SubzoneForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingSubzone.Id);
            Assert.AreEqual("Subzone 1", testingSubzone.Name);
            Assert.AreEqual(3, testingSubzone.Capacity);
            Assert.AreEqual(testingZone, testingSubzone.ContainerZone);
        }

        [TestMethod]
        public void SubzoneSetIdValidTest()
        {
            testingSubzone.Id = 42;
            Assert.AreEqual(42, testingSubzone.Id);
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

        [TestMethod]
        public void SubzoneSetValidContainerZoneTest()
        {
            Zone alternativeZone = Zone.CreateNewZone("Alternative zone", 3);
            testingSubzone.ContainerZone = alternativeZone;
            Assert.AreEqual(alternativeZone, testingSubzone.ContainerZone);
        }

        [ExpectedException(typeof(SubzoneException))]
        [TestMethod]
        public void SubzoneSetInvalidContainerZoneNullTest()
        {
            testingSubzone.ContainerZone = null;
        }

        [TestMethod]
        public void SubzoneParameterFactoryMethodValidTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Some subzone", 26, testingZone);
            Assert.AreEqual(0, testingSubzone.Id);
            Assert.AreEqual("Some subzone", testingSubzone.Name);
            Assert.AreEqual(26, testingSubzone.Capacity);
            Assert.AreEqual(testingZone, testingSubzone.ContainerZone);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidNameTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("!@#$%", 23, testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidCapacityTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Another subzone", 0, testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidContainerZoneTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Another subzone", 23, null);
        }

        [TestMethod]
        public void SubzoneEqualsReflexiveTest()
        {
            Assert.AreEqual(testingSubzone, testingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsSymmetricTest()
        {
            Subzone secondTestingSubzone = Subzone.InstanceForTestingPurposes();
            Assert.AreEqual(testingSubzone, secondTestingSubzone);
            Assert.AreEqual(secondTestingSubzone, testingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsTransitiveTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, testingZone);
            Subzone secondTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, testingZone);
            Subzone thirdTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, testingZone);
            Assert.AreEqual(testingSubzone, secondTestingSubzone);
            Assert.AreEqual(secondTestingSubzone, thirdTestingSubzone);
            Assert.AreEqual(testingSubzone, thirdTestingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsDifferentSubzonesTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Subzone1", 8, testingZone);
            testingSubzone.Id = 1;
            Subzone secondTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 8, testingZone);
            secondTestingSubzone.Id = 2;
            Assert.AreNotEqual(testingSubzone, secondTestingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsNullTest()
        {
            Assert.AreNotEqual(testingSubzone, null);
        }

        [TestMethod]
        public void SubzoneEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingSubzone, someRandomObject);
        }

        [TestMethod]
        public void SubzoneGetHashCodeTest()
        {
            object testingSubzoneAsObject = testingSubzone;
            Assert.AreEqual(testingSubzoneAsObject.GetHashCode(), testingSubzone.GetHashCode());
        }
    }
}
