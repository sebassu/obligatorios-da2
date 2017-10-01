using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class ProcessDataTests
    {
        private static ProcessData testingData;
        private static readonly Lot lotToSet = Lot.InstanceForTestingPurposes();

        [TestInitialize]
        public void TestSetup()
        {
            testingData = new ProcessData();
        }

        [TestMethod]
        public void ProcessDataRegisterPortLotValidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.RegisterPortLot(lotToSet);
            Assert.AreEqual(lotToSet, testingData.PortLot);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullPortLotInvalidTest()
        {
            testingData.RegisterPortLot(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortLotOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterPortLot(lotToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortLotOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterPortLot(lotToSet);
        }
    }
}
