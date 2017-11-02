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
        public void FlowSetRequiredSubzonesEmptyEnumerationInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = new List<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetRequiredSubzonesNullEnumerationInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = null;
        }

        [TestMethod]
        public void FlowParameterFactoryMethodValidTest()
        {
            testingFlow = Flow.FromSubzoneNames(testingSubzoneNames);
            Assert.AreSame(testingSubzoneNames, testingFlow.RequiredSubzoneNames);
            Assert.AreEqual("A,B,C", testingFlow.EncodedSubzoneNames);
        }

        [TestMethod]
        public void FlowParameterFactoryMethodWithDuplicatesValidTest()
        {
            var subzoneNamesWithDuplicates = new List<string>() { "A", "A" };
            testingFlow = Flow.FromSubzoneNames(subzoneNamesWithDuplicates);
            Assert.AreSame(subzoneNamesWithDuplicates, testingFlow.RequiredSubzoneNames);
            Assert.AreEqual("A,A", testingFlow.EncodedSubzoneNames);
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowParameterFactoryMethodEmptyEnumerationInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = new List<string>();
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowParameterFactoryMethodNullEnumerationInvalidTest()
        {
            testingFlow.RequiredSubzoneNames = null;
        }
    }
}