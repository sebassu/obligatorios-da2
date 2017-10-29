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
                testingLoggingRecord.ElementIdentifier);
            Assert.AreEqual(DateTime.Today,
                testingLoggingRecord.DateTime.Date);
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
            testingLoggingRecord.ActionPerformed = LoggedActions.USER_CREATION;
            Assert.AreEqual(LoggedActions.USER_CREATION,
                testingLoggingRecord.ActionPerformed);
        }

        [TestMethod]
        public void LoggingRecordSetElementIdentifierUsernameValidTest()
        {
            testingLoggingRecord.ElementIdentifier = "mSantos";
            Assert.AreEqual("mSantos", testingLoggingRecord.ElementIdentifier);
        }

        [TestMethod]
        public void LoggingRecordSetElementIdentifierVINValidTest()
        {
            testingLoggingRecord.ElementIdentifier = "RUSH2112MVNGPCTRS";
            Assert.AreEqual("RUSH2112MVNGPCTRS",
                testingLoggingRecord.ElementIdentifier);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetElementPunctuationIdentifierInvalidTest()
        {
            testingLoggingRecord.ElementIdentifier = "32*/*@^--&#&$";
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetElementEmptyIdentifierInvalidTest()
        {
            testingLoggingRecord.ElementIdentifier = "";
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingRecordException))]
        public void LoggingRecordSetElementNullIdentifierInvalidTest()
        {
            testingLoggingRecord.ElementIdentifier = null;
        }
    }
}