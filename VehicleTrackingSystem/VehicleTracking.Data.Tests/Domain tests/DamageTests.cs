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
    public class DamageTests
    {
        private static Damage testingDamage;

        [TestInitialize]
        public void TestSetup()
        {
            testingDamage = Damage.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void DamageForTestingPurposesTest()
        {
            Assert.AreEqual("This damage has a description", testingDamage.Description);
            Assert.IsTrue(testingDamage.Images.Contains("newImage"));
        }

        //Damage Description
        [TestMethod]
        public void DamageSetValidDescriptionTest()
        {
            testingDamage.Description = "This damage has a new description";
            Assert.AreEqual("This damage has a new description", testingDamage.Description);
        }

        [TestMethod]
        public void DamageSetValidDescriptionCompoundTest()
        {
            testingDamage.Description = "  The new description. ";
            Assert.AreEqual("The new description.", testingDamage.Description);
        }

        [TestMethod]
        public void DamageSetValidDescriptionNumbersTest()
        {
            testingDamage.Description = "2 broken windows";
            Assert.AreEqual("2 broken windows", testingDamage.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageSetInvalidDescriptionEmptyTest()
        {
            testingDamage.Description = "";
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageSetInvalidDescriptionOnlySpacesTest()
        {
            testingDamage.Description = "     ";
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageSetInvalidDescriptionNullTest()
        {
            testingDamage.Description = null;
        }

        //Damage Images
        [TestMethod]
        public void DamageAddValidImageTest()
        {
            string img = "newImageString";
            testingDamage.Images.Add(img);
            Assert.IsTrue(testingDamage.Images.Contains(img));
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageEmptyTest()
        {
            testingDamage.Image = "";
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageOnlySpacesTest()
        {
            testingDamage.Image = "     ";
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageNullTest()
        {
            testingDamage.Image = null;
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddRepeatedImageInvalidTest()
        {
            testingDamage.Image = "imageString";
        }
    }
}
