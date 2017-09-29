using Moq;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.API.Tests
{
    public static class ControllerTestsUtilities
    {
        public static void VerifyMethodReturnsOkResponse(Func<IHttpActionResult> methodToTest,
            Mock mockVehicleServices)
        {
            IHttpActionResult result = methodToTest.Invoke();
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        public static void VerifyMethodReturnsBadRequestResponse(Func<IHttpActionResult> methodToTest,
            Mock mockVehicleServices, string expectedErrorMessage)
        {
            IHttpActionResult obtainedResult = methodToTest.Invoke();
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }

        public static void VerifyMethodReturnsServerErrorResponse(Func<IHttpActionResult> methodToTest,
            Mock mockUsersServices, Exception expectedException)
        {
            var result = methodToTest.Invoke() as ExceptionResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedException, result.Exception);
        }
    }
}
