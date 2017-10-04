using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class TransportTests
    {
        private static Transport testingTransport;
        private static readonly User testingUser = User.InstanceForTestingPurposes();

        [TestInitialize]
        public void TestSetup()
        {
            testingTransport = Transport.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void TransportSetIdValidTest()
        {
            testingTransport.Id = 42;
            Assert.AreEqual(42, testingTransport.Id);
        }

        [TestMethod]
        public void TransportInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingTransport.Id);
            Assert.AreEqual(User.InstanceForTestingPurposes(),
                testingTransport.Transporter);
            Assert.IsNotNull(testingTransport.LotsTransported);
            Assert.AreEqual(0, testingTransport.LotsTransported.Count);
        }

        [TestMethod]
        public void TransportSetAdministratorTransporterValidTest()
        {
            Assert.AreEqual(UserRoles.ADMINISTRATOR, testingUser.Role);
            testingTransport.Transporter = testingUser;
            Assert.AreSame(testingUser, testingTransport.Transporter);
        }

        [TestMethod]
        public void TransportSetTranporterTransporterValidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne", "NoHaceFaltaSaleSolo", "099212121");
            testingTransport.Transporter = transporterToSet;
            Assert.AreSame(transporterToSet, testingTransport.Transporter);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetPortOperatorTransporterInvalidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669");
            testingTransport.Transporter = transporterToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetYardOperatorTransporterInvalidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669");
            testingTransport.Transporter = transporterToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetNullTransporterInvalidTest()
        {
            testingTransport.Transporter = null;
        }
    }
}
