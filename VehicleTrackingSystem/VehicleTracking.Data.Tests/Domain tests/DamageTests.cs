using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;
using System.Linq;

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
        
        [TestMethod]
        public void DamageSetValidDescriptionTest()
        {
            testingDamage.Description = "This damage has a new description";
            Assert.AreEqual("This damage has a new description", testingDamage.Description);
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
        
        [TestMethod]
        public void DamageAddValidImageTest()
        {
            string img = "anotherNewImage";
            testingDamage.AddImage(img);
            Assert.IsTrue(testingDamage.Images.Contains(img));
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageEmptyTest()
        {
            testingDamage.AddImage("");
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageOnlySpacesTest()
        {
            testingDamage.AddImage("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddInvalidImageNullTest()
        {
            testingDamage.AddImage(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageAddRepeatedImageInvalidTest()
        {
            testingDamage.AddImage("newImage");
        }

        [TestMethod]
        public void DamageSetValidImagesListTest()
        {
            List<string> aux = new List<string>();
            aux.Add("Image1");
            aux.Add("Image2");
            testingDamage.Images = aux;
            Assert.IsTrue(testingDamage.Images.SequenceEqual(aux));
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageSetInvalidImagesListEmptyTest()
        {
            testingDamage.Images = new List<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageSetInvalidImagesNullTest()
        {
            testingDamage.Images = null;
        }

        [TestMethod]
        public void DamageParameterFactoryMethodValidTest()
        {
            List<string> aux = new List<string>();
            aux.Add("Image1");
            aux.Add("Image2");
            testingDamage = Damage.CreateNewDamage("A description", aux);
            Assert.AreEqual("A description", testingDamage.Description);
            Assert.IsTrue(aux.SequenceEqual(testingDamage.Images));
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageParameterFactoryMethodInvalidDescriptionTest()
        {
            List<string> aux = new List<string>();
            aux.Add("Image1");
            aux.Add("Image2");
            testingDamage = Damage.CreateNewDamage("", aux);
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageParameterFactoryMethodInvalidNullTest()
        {
            testingDamage = Damage.CreateNewDamage("Some description", null);
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageParameterFactoryMethodInvalidImagesEmptyTest()
        {
            testingDamage = Damage.CreateNewDamage("Some description", new List<string>());
        }

        [TestMethod]
        public void DamageEqualsNullTest()
        {
            Assert.AreNotEqual(testingDamage, null);
        }

        [TestMethod]
        public void DamageEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingDamage, someRandomObject);
        }

        [TestMethod]
        public void InspectionEqualsReflexiveTest()
        {
            Assert.AreEqual(testingDamage, testingDamage);
        }

        [TestMethod]
        public void InspectionEqualsSymmetricTest()
        {
            Damage secondTestingDamage = Damage.InstanceForTestingPurposes();
            Assert.AreEqual(testingDamage, secondTestingDamage);
            Assert.AreEqual(secondTestingDamage, testingDamage);
        }
    }
}
