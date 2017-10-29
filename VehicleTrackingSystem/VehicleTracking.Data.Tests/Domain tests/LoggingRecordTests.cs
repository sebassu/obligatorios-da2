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
            User responsibleToSet = User.InstanceForTestingPurposes();
            testingLoggingRecord.Responsible = responsibleToSet;
            Assert.AreEqual(responsibleToSet, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        public void LoggingRecordSetPortOperatorResponsibleValidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.PORT_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
            Assert.AreEqual(responsibleToSet, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        public void LoggingRecordSetTransporterResponsibleValidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.TRANSPORTER;
            testingLoggingRecord.Responsible = responsibleToSet;
            Assert.AreEqual(responsibleToSet, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        public void LoggingRecordSetYardOperatorResponsibleValidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.YARD_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
            Assert.AreEqual(responsibleToSet, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        public void LoggingRecordSetSalesmanResponsibleValidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.SALESMAN;
            testingLoggingRecord.Responsible = responsibleToSet;
            Assert.AreEqual(responsibleToSet, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        public void LoggingRecordSetNullResponsibleValidTest()
        {
            testingLoggingRecord.Responsible = null;
            Assert.IsNull(testingLoggingRecord.Responsible);
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
        public void LoggingRecordParameterFactoryMethodAdministratorValidTest()
        {
            User administrator = User.InstanceForTestingPurposes();
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                administrator, LoggedActions.LOGIN);
            Assert.AreSame(administrator, testingLoggingRecord.Responsible);
            Assert.AreEqual(LoggedActions.LOGIN, testingLoggingRecord.ActionPerformed);
            Assert.AreEqual(DateTime.Today, testingLoggingRecord.DateTime.Date);
        }

        [TestMethod]
        public void LoggingRecordParameterFactoryMethodOtherRoleValidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.SALESMAN;
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                responsibleToSet, LoggedActions.LOGIN);
            Assert.AreSame(responsibleToSet, testingLoggingRecord.Responsible);
            Assert.AreEqual(LoggedActions.LOGIN, testingLoggingRecord.ActionPerformed);
            Assert.AreEqual(DateTime.Today, testingLoggingRecord.DateTime.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryInvalidRoleForActionTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.TRANSPORTER;
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
                responsibleToSet, LoggedActions.VEHICLE_IMPORT);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordParameterFactoryMethodNullUserInvalidTest()
        {
            testingLoggingRecord = LoggingRecord.FromResponsibleActionPerformed(
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
    }
}