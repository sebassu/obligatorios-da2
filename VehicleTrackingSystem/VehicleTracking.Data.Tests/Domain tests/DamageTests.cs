using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DamageTests
    {
        private static Damage testingDamage;
        private static List<string> imagesDataToAdd;
        private static string testImagesLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\";

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            ImageConverter converter = new ImageConverter();
            var image1Data = "data:image/jpeg;base64," + GetImageDataFromFileWithName("TestImage1.jpg",
                converter);
            var image2Data = "data:image/jpeg;base64," + GetImageDataFromFileWithName("TestImage2.jpg",
                converter);
            imagesDataToAdd = new List<string> { image1Data, image2Data };
        }

        private static string GetImageDataFromFileWithName(string fileName,
            ImageConverter converter)
        {
            var testImage = Image.FromFile(testImagesLocation + fileName);
            var testImageData = converter.ConvertTo(testImage,
                typeof(byte[])) as byte[];
            return Convert.ToBase64String(testImageData);
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingDamage = Damage.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void DamageInstanceForTestingPurposesTest()
        {
            Assert.AreEqual("This damage has a description", testingDamage.Description);
            Assert.IsNotNull(testingDamage.Images);
        }

        [TestMethod]
        public void DamageSetIdValidTest()
        {
            testingDamage.Id = 42;
            Assert.AreEqual(42, testingDamage.Id);
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
        public void DamageSetValidImagesListTest()
        {
            testingDamage.Images = imagesDataToAdd;
            CollectionAssert.AreEqual(imagesDataToAdd,
                testingDamage.Images.ToList());
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
            testingDamage = Damage.CreateNewDamage("A description", imagesDataToAdd);
            Assert.AreEqual("A description", testingDamage.Description);
            CollectionAssert.AreEqual(imagesDataToAdd,
                testingDamage.Images.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(DamageException))]
        public void DamageParameterFactoryMethodInvalidDescriptionTest()
        {
            testingDamage = Damage.CreateNewDamage("", imagesDataToAdd);
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
            testingDamage = Damage.CreateNewDamage("Some description",
                new List<string>());
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
        [TestMethod]
        public void UserGetHashCodeTest()
        {
            object testingDamageAsObject = testingDamage;
            Assert.AreEqual(testingDamageAsObject.GetHashCode(),
                testingDamage.GetHashCode());
        }
    }
}
