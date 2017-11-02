using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    public class FlowTests
    {
        private static Flow testingFlow;
        private static readonly IEnumerable<string> testingSubzoneNames
            = new List<string>() { "A", "B", "C" };

        [TestInitialize]
        public void TestSetup()
        {
            testingFlow = Flow.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void FlowSetRequiredSubzonesValidTest()
        {
            testingFlow.RequiredSubzoneNames = testingSubzoneNames;
            Assert.AreSame(testingSubzoneNames, testingFlow.RequiredSubzoneNames);
        }

        [TestMethod]
        public void FlowSetRequiredSubzonesWithDuplicatesValidTest()
        {
            var subzoneNamesWithDuplicates = new List<string>() { "A", "A" };
            testingFlow.RequiredSubzoneNames = subzoneNamesWithDuplicates;
            Assert.AreSame(subzoneNamesWithDuplicates, testingFlow.RequiredSubzoneNames);
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetRequiredSubzonesEmptyListInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = new List<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetRequiredSubzonesNullListInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = null;
        }
    }
}