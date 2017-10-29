using Domain;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
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
            Assert.IsNull(testingLoggingRecord.Responsible);
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
        public void LoggingRecordSetValidResponsibleTest()
        {
            User administrator = User.InstanceForTestingPurposes();
            testingLoggingRecord.Responsible = administrator;
            Assert.AreEqual(administrator, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetPortOperatorResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.PORT_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetTransporterResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.TRANSPORTER;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetYardOperatorResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.YARD_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetSalesmanResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.SALESMAN;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetNullResponsibleInvalidTest()
        {
            testingLoggingRecord.Responsible = null;
        }

        [TestMethod]
        public void LoggingRecordSetActionPerformedImportValidTest()
        {
            testingLoggingRecord.ActionPerformed = LoggedActions.VEHICLE_IMPORT;
            Assert.AreEqual(LoggedActions.VEHICLE_IMPORT,
                testingLoggingRecord.ActionPerformed);
        }

        [TestMethod]
        public void LoggingRecordSetActionTypeUserCreationValidTest()
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
            User administrator = User.InstanceForTestingPurposes();
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                administrator, LoggedActions.LOGIN);
            Assert.AreSame(administrator, testingLoggingRecord.Responsible);
            Assert.AreEqual(LoggedActions.LOGIN, testingLoggingRecord.ActionPerformed);
            Assert.AreEqual(DateTime.Today, testingLoggingRecord.DateTime.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordParameterFactoryMethodInvalidUserRoleTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.SALESMAN;
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                responsibleToSet, LoggedActions.LOGIN);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordParameterFactoryMethodNullUserInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                null, LoggedActions.LOGIN);
        }
    }
}