using Moq;
using API.Services;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using VehicleTracking_Data_DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.API.Tests.Services_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FlowServicesTests
    {
        private static readonly FlowServices testingFlowServices = new FlowServices();
        private static readonly List<string> testingFlowData = new List<string>(new string[]
        { "Subzone 1", "Subzone 2", "Subzone 3" });

        [TestMethod]
        public void FServicesDefaultParameterlessConstructorTest()
        {
            Assert.IsNotNull(testingFlowServices.Model);
            Assert.IsNotNull(testingFlowServices.Flows);
        }

        #region AddNewFlow tests
        [TestMethod]
        public void FServicesAddNewFlowFromDataValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Flow.RegisterNewFlow(It.IsAny<Flow>()))
                .Verifiable();
            mockUnitOfWork.Setup(u => u.Vehicles.GetRegisteredVehiclesIn(
                ProcessStages.YARD)).Returns(new List<Vehicle>()).Verifiable();
            var flowServices = new FlowServices(mockUnitOfWork.Object);
            flowServices.AddNewFlowFromData(testingFlowData);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void FServicesAddNewFlowFromNullDataInvalidTest()
        {
            testingFlowServices.AddNewFlowFromData(null);
        }
        #endregion

        #region GetFlow tests
        [TestMethod]
        public void FServicesGetRegisteredFlowWithDataTest()
        {
            var flow = GetFlow();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(f => f.Flow.GetCurrentFlow()).Returns(flow).Verifiable();
            var flowServices = new FlowServices(mockUnitOfWork.Object);
            var result = flowServices.GetRegisteredFlow();
            mockUnitOfWork.Verify();
            Assert.AreEqual(GetFlow(), result);
        }

        private Flow GetFlow()
        {
            return Flow.FromSubzoneNames(testingFlowData);
        }
        #endregion
    }
}
