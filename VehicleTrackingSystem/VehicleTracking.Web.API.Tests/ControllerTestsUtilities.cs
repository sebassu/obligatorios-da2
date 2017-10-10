using Moq;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Web.API.Tests
{
    [ExcludeFromCodeCoverage]
    public static class ControllerTestsUtilities
    {
        public static void VerifyMethodReturnsOkResponse(Func<IHttpActionResult> methodToTest,
            Mock mockVehicleServices)
        {
            IHttpActionResult obtainedResult = methodToTest.Invoke();
            mockVehicleServices.VerifyAll();
            var result = obtainedResult as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
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
