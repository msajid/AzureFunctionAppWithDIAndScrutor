using AzureFunctionAppWithDIAndScrutor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureFunctionApp.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Http_trigger_should_return_OK()
        {
            var mockService = new Moq.Mock<ISomeService>();
            mockService.Setup(m => m.DoSomething());
            var function = new SimpleFunction(mockService.Object);
            var request = new DefaultHttpRequest(new DefaultHttpContext());
            var response = (OkObjectResult)function.Run(request).GetAwaiter().GetResult();
            Assert.AreEqual(StatusCodes.Status200OK,response.StatusCode);
        }
    }
}
