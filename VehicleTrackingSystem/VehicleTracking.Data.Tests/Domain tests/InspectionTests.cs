using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class InspectionTests
    {
        private static Inspection testingInspection;

        [TestInitialize]
        public void TestSetup()
        {
            testingInspection = Inspection.InstanceForTestingPurposes();

        }

        [TestMethod]
        public void VehicleForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingInspection.Id);
            Assert.AreEqual(new DateTime(2017, 9, 22, 10, 8, 0), testingInspection.DateTime);
        }

        [TestMethod]
        public void InspectionSetValidDateTimeTest()
        {
            testingInspection.DateTime = DateTime.Now;
            Assert.AreEqual(DateTime.Now, testingInspection.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDatePassTodayTest()
        {
            testingInspection.DateTime = new DateTime(2019, 9, 24, 10, 9, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDateTimeOldTest()
        {
            testingInspection.DateTime = new DateTime(1856, 8, 30, 12, 8, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDateTimeEmptyTest()
        {
            testingInspection.DateTime = null;
        }
    }
}
