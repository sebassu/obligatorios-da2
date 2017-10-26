using Domain;
using System.IO;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Data.Domain_tests
{
    [TestClass]
    public class ImageElementTests
    {
        private static ImageElement testingImageElement;
        private static byte[] testImageBinaryData;
        private static string testImageLocation = Directory.GetParent(
            Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\TestImage.jpg";

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            Image testImage = Image.FromFile(testImageLocation);
            ImageConverter converter = new ImageConverter();
            testImageBinaryData = converter.ConvertTo(testImage,
                typeof(byte[])) as byte[];
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingImageElement = ImageElement.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ImageElementSetIdValidTest()
        {
            testingImageElement.Id = 42;
            Assert.AreEqual(42, testingImageElement.Id);
        }

        [TestMethod]
        public void ImageElementSetImageDataValidTest()
        {
            testingImageElement.ImageData = testImageBinaryData;
            Assert.AreSame(testImageBinaryData, testingImageElement.ImageData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementSetImageRandomDataInvalidTest()
        {
            byte[] someRandomData = new byte[3] { 1, 0, 1 };
            testingImageElement.ImageData = someRandomData;
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementSetImageEmptyDataInvalidTest()
        {
            testingImageElement.ImageData = new byte[7];
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementSetImageNullDataInvalidTest()
        {
            testingImageElement.ImageData = null;
        }

        [TestMethod]
        public void ImageElementFromImageDataValidTest()
        {
            var imageDataToSet = Convert.ToBase64String(testImageBinaryData);
            testingImageElement = ImageElement.FromImageData(imageDataToSet);
            CollectionAssert.AreEqual(testImageBinaryData,
                testingImageElement.ImageData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementFromImageRandomDataInvalidTest()
        {
            ImageElement.FromImageData("En el" +
                " habitual espacio lírico.");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementFromImageEmptyDataInvalidTest()
        {
            ImageElement.FromImageData("");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleTrackingException))]
        public void ImageElementFromImageNullDataInvalidTest()
        {
            ImageElement.FromImageData(null);
        }

        [TestMethod]
        public void ImageElementStringifiedImageValidTest()
        {
            var imageDataToSet = Convert.ToBase64String(testImageBinaryData);
            testingImageElement = ImageElement.FromImageData(imageDataToSet);
            Assert.AreEqual(imageDataToSet, testingImageElement.StringifiedImage);
        }
    }
}