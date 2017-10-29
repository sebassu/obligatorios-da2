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
            Assert.AreEqual("Registro de acción inválido.",
                testingLoggingRecord.Identifier);
            Assert.AreEqual(DateTime.MinValue, testingLoggingRecord.DateTime);
        }

        [TestMethod]
        public void LoggingRecordSetValidResponsibleTest()
        {
            User administrator = User.InstanceForTestingPurposes();
            testingLoggingRecord.Responsible = administrator;
            Assert.AreEqual(administrator, testingLoggingRecord.Responsible);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetPortOperatorResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.PORT_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetTransporterResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.TRANSPORTER;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetYardOperatorResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.YARD_OPERATOR;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LoggingRecordSetSalesmanResponsibleInvalidTest()
        {
            User responsibleToSet = User.InstanceForTestingPurposes();
            responsibleToSet.Role = UserRoles.SALESMAN;
            testingLoggingRecord.Responsible = responsibleToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
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
            testingLoggingRecord.ActionPerformed = LoggedActions.USER_CREATION;
            Assert.AreEqual(LoggedActions.USER_CREATION,
                testingLoggingRecord.ActionPerformed);
        }
    }
}