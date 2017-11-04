using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Data.Domain_tests
{
    [TestClass]
    public class FlowTests
    {
        private static Flow testingFlow;
        private static readonly List<string> testingSubzoneNames
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
        public void FlowSetRequiredSubzonesWithInvalidContentsValidTest()
        {
            var subzoneNamesWithInvalidContents = new List<string>() { "Valid subzone",
                "12#&$^$^#^ ***-,1" };
            testingFlow.RequiredSubzoneNames = subzoneNamesWithInvalidContents;
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
            CollectionAssert.AreEqual(testingSubzoneNames,
                testingFlow.RequiredSubzoneNames.ToList());
            Assert.AreEqual("A,B,C", testingFlow.EncodedSubzoneNames);
        }

        [TestMethod]
        public void FlowParameterFactoryMethodWithDuplicatesValidTest()
        {
            var subzoneNamesWithDuplicates = new List<string>() { "A", "A" };
            testingFlow = Flow.FromSubzoneNames(subzoneNamesWithDuplicates);
            CollectionAssert.AreEqual(subzoneNamesWithDuplicates,
                testingFlow.RequiredSubzoneNames.ToList());
            Assert.AreEqual("A,A", testingFlow.EncodedSubzoneNames);
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowParameterFactoryMethodWithInvalidContentTest()
        {
            var subzoneNamesWithInvalidContents = new List<string>() {
                "49 !&^!!_-+>> ,*#", "Valid subzone" };
            Flow.FromSubzoneNames(subzoneNamesWithInvalidContents);
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

        [TestMethod]
        public void FlowSetEncodedSubzoneNamesValidTest()
        {
            testingFlow.EncodedSubzoneNames = "A,B,C";
            Assert.AreEqual("A,B,C", testingFlow.EncodedSubzoneNames);
            CollectionAssert.AreEqual(testingSubzoneNames.ToList(),
                testingFlow.RequiredSubzoneNames.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetEncodedSubzoneNamesStringWithEmptySpacesInvalidTest()
        {
            testingFlow.EncodedSubzoneNames = ",Valid subzone,,";
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetEncodedSubzoneNamesWithRandomDataInvalidTest()
        {
            testingFlow.EncodedSubzoneNames = "Valid subzone, )as!!/$/%$-*";
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetEmptyEncodedSubzoneNamesInvalidTest()
        {
            testingFlow.EncodedSubzoneNames = "";
        }

        [TestMethod]
        [ExpectedException(typeof(FlowException))]
        public void FlowSetNullEncodedSubzoneNamesInvalidTest()
        {
            testingFlow.EncodedSubzoneNames = null;
        }
    }
}