using Domain;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
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
        public void FlowInstanceForTestingPurposesTest()
        {
            Assert.AreEqual("Mecánica ligera,Lavado,Pintura",
                testingFlow.EncodedSubzoneNames);
            CollectionAssert.AreEqual(new List<string>() {
                "Mecánica ligera", "Lavado", "Pintura" },
                testingFlow.RequiredSubzoneNames.ToList());
        }

        [TestMethod]
        public void FlowSetIdValidTest()
        {
            testingFlow.Id = 42;
            Assert.AreEqual(42, testingFlow.Id);
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

        [TestMethod]
        public void FlowEqualsReflexiveTest()
        {
            Assert.AreEqual(testingFlow, testingFlow);
        }

        [TestMethod]
        public void FlowEqualsSymmetricTest()
        {
            Flow secondTestingFlow = Flow.InstanceForTestingPurposes();
            Assert.AreEqual(testingFlow, secondTestingFlow);
            Assert.AreEqual(secondTestingFlow, testingFlow);
        }

        [TestMethod]
        public void FlowEqualsTransitiveTest()
        {
            testingFlow = Flow.FromSubzoneNames(new List<string>() { "A", "B", "C" });
            Flow secondTestingFlow = Flow.FromSubzoneNames(new List<string>() {
                "A", "B", "C" });
            Flow thirdTestingFlow = Flow.FromSubzoneNames(new List<string>() {
                "A", "B", "C" });
            Assert.AreEqual(testingFlow, secondTestingFlow);
            Assert.AreEqual(secondTestingFlow, thirdTestingFlow);
            Assert.AreEqual(testingFlow, thirdTestingFlow);
        }

        [TestMethod]
        public void FlowEqualsDifferentFlowSubzonesTest()
        {
            testingFlow = Flow.FromSubzoneNames(new List<string>() { "A", "B" });
            Flow secondTestingFlow = Flow.FromSubzoneNames(new List<string>() { "C", "D" });
            Assert.AreNotEqual(testingFlow, secondTestingFlow);
        }

        [TestMethod]
        public void FlowEqualsDifferentFlowWithAdditionalSubzonesTest()
        {
            testingFlow = Flow.FromSubzoneNames(new List<string>() { "A", "B" });
            Flow secondTestingFlow = Flow.FromSubzoneNames(new List<string>() {
                "A", "B", "C" });
            Assert.AreNotEqual(testingFlow, secondTestingFlow);
        }

        [TestMethod]
        public void FlowEqualsNullTest()
        {
            Assert.AreNotEqual(testingFlow, null);
        }

        [TestMethod]
        public void FlowEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingFlow, someRandomObject);
        }

        [TestMethod]
        public void FlowGetHashCodeTest()
        {
            object testingFlowAsObject = testingFlow;
            Assert.AreEqual(testingFlowAsObject.GetHashCode(),
                testingFlow.GetHashCode());
        }
    }
}