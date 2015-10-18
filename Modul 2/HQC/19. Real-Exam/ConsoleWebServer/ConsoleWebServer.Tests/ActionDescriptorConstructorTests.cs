namespace ConsoleWebServer.Tests
{
    using Framework;
    using Framework.HttpServerLogic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ActionDescriptorConstructorTests
    {
        [TestMethod]
        public void InvokingConstructorWithNullShouldReturnDefaultControllerActionAndParameter()
        {
            var actionDescriptor = new ActionDescriptor(null);

            Assert.AreEqual("Home", actionDescriptor.ControllerName);
            Assert.AreEqual("Index", actionDescriptor.ActionName);
            Assert.AreEqual(string.Empty, actionDescriptor.Parameter);
        }

        [TestMethod]
        public void InvokingConstructorWithSlashShouldReturnDefaultControllerActionAndParameter()
        {
            var actionDescriptor = new ActionDescriptor("/");

            Assert.AreEqual("Home", actionDescriptor.ControllerName);
            Assert.AreEqual("Index", actionDescriptor.ActionName);
            Assert.AreEqual(string.Empty, actionDescriptor.Parameter);
        }

        [TestMethod]
        public void InvokingConstructorWithHomeControllerShouldReturnDefaultActionAndParameter()
        {
            var actionDescriptor = new ActionDescriptor("/Home");

            Assert.AreEqual("Index", actionDescriptor.ActionName);
            Assert.AreEqual(string.Empty, actionDescriptor.Parameter);
        }

        [TestMethod]
        public void InvokingConstructorWithMissingParameterShouldReturnDefaultParameter()
        {
            var actionDescriptor = new ActionDescriptor("/Home/Index");

            Assert.AreEqual(string.Empty, actionDescriptor.Parameter);
        }

        [TestMethod]
        public void InvokingConstructorWithNormalUriShouldReturnProperlyControllerActionAndParameter()
        {
            var actionDescriptor = new ActionDescriptor("/Api/ResponseMessage/someParam123");

            Assert.AreEqual("Api", actionDescriptor.ControllerName);
            Assert.AreEqual("ResponseMessage", actionDescriptor.ActionName);
            Assert.AreEqual("someParam123", actionDescriptor.Parameter);
        }
    }
}