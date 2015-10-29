namespace ConsoleWebServer.Tests
{
    using Application.Controllers;
    using Framework.HttpServerLogic;
    using Framework.JsonActionResults;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApiControllerReturnMeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string Param = "someParam";

            var httpRequest = new HttpRequest("GET", "/Home/LivePageForAjax", "HTTP/1.1");
            var apiController = new ApiController(httpRequest);
            var jsonActionResult = new JsonActionResultBase(httpRequest, new { Param });

            var actual = apiController.ResponseMessage(Param);
        }
    }
}