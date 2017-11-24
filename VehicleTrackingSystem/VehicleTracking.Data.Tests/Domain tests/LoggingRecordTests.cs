using System;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LoggingRecordTests
    {
        private static LoggingRecord testingLoggingRecord;

        [TestInitialize]
        public void TestSetup()
        {
            testingLoggingRecord = LoggingRecord.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void LoggingRecordInstanceForTestingPurposesTest()
        {
            Assert.IsNull(testingLoggingRecord.ResponsiblesUsername);
            Assert.AreEqual(DateTime.Today,
                testingLoggingRecord.DateTime.Date);
        }

        [TestMethod]
        public void LoggingRecordSetIdentifierValidTest()
        {
            testingLoggingRecord.Id = 42;
            Assert.AreEqual(42, testingLoggingRecord.Id);
        }

        [TestMethod]
        public void LoggingRecordSetValidResponsiblesUsernameTest()
        {
            testingLoggingRecord.ResponsiblesUsername = "mSantos";
            Assert.AreEqual("mSantos", testingLoggingRecord.ResponsiblesUsername);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetResponsiblesUsernameWithSpacesInvalidTest()
        {
            testingLoggingRecord.ResponsiblesUsername = "En el habitual espacio";
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetPunctuationResponsiblesUsernameInvalidTest()
        {
            testingLoggingRecord.ResponsiblesUsername = "1@#* *// -^$*";
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetEmptyResponsiblesUsernameInvalidTest()
        {
            testingLoggingRecord.ResponsiblesUsername = "";
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetNullResponsiblesUsernameInvalidTest()
        {
            testingLoggingRecord.ResponsiblesUsername = null;
        }

        [TestMethod]
        public void LoggingRecordSetActionPerformedImportValidTest()
        {
            testingLoggingRecord.ActionPerformed = LoggedActions.VEHICLE_IMPORT;
            Assert.AreEqual(LoggedActions.VEHICLE_IMPORT,
                testingLoggingRecord.ActionPerformed);
        }

        [TestMethod]
        public void LoggingRecordSetActionTypeUserLoginValidTest()
        {
            testingLoggingRecord.ActionPerformed = LoggedActions.LOGIN;
            Assert.AreEqual(LoggedActions.LOGIN,
                testingLoggingRecord.ActionPerformed);
        }

        [TestMethod]
        public void LoggingRecordSetDateTimeValidTest()
        {
            testingLoggingRecord.DateTime = DateTime.MinValue;
            Assert.AreEqual(DateTime.MinValue,
                testingLoggingRecord.DateTime);
        }

        [TestMethod]
        public void LoggingRecordParameterFactoryMethodValidTest()
        {
            testingLoggingRecord = LoggingRecord.FromUsernameAction("mSantos",
                LoggedActions.LOGIN);
            Assert.AreEqual("mSantos", testingLoggingRecord.ResponsiblesUsername);
            Assert.AreEqual(LoggedActions.LOGIN, testingLoggingRecord.ActionPerformed);
            Assert.AreEqual(DateTime.Today, testingLoggingRecord.DateTime.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryMethodUsernameWithSpacesInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromUsernameAction(
                "En el habitual espacio", LoggedActions.LOGIN);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryMethodPunctuationUsernameInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromUsernameAction(
                ")#(*$33-***/$)*%&", LoggedActions.LOGIN);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryMethodEmptyUsernameInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromUsernameAction(
                "", LoggedActions.LOGIN);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryMethodNullUsernameInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromUsernameAction(
                null, LoggedActions.LOGIN);
        }

        [TestMethod]
        public void LoggingRecordEqualsSameObjectValidTest()
        {
            Assert.AreEqual(testingLoggingRecord, testingLoggingRecord);
        }

        [TestMethod]
        public void LoggingRecordEqualsSameIdValidTest()
        {
            var someOtherLoggingRecord = LoggingRecord.InstanceForTestingPurposes();
            someOtherLoggingRecord.Id = testingLoggingRecord.Id;
            Assert.AreEqual(testingLoggingRecord, someOtherLoggingRecord);
        }

        [TestMethod]
        public void LoggingRecordEqualsDifferentIdTest()
        {
            var someOtherLoggingRecord = LoggingRecord.InstanceForTestingPurposes();
            someOtherLoggingRecord.Id = testingLoggingRecord.Id + 42;
            Assert.AreNotEqual(testingLoggingRecord, someOtherLoggingRecord);
        }

        [TestMethod]
        public void LoggingRecordEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingLoggingRecord, someRandomObject);
        }

        [TestMethod]
        public void LoggingRecordEqualsNullTest()
        {
            Assert.AreNotEqual(testingLoggingRecord, null);
        }

        [TestMethod]
        public void LoggingRecordGetHashCodeTest()
        {
            object testingLoggingRecordAsObject = testingLoggingRecord;
            Assert.AreEqual(testingLoggingRecordAsObject.GetHashCode(),
                testingLoggingRecord.GetHashCode());
        }
    }
}