namespace RegistrationTelerikAcademyTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using Pages.Facades;

    using Utils;

    [TestClass]
    public class RegistrationTelerikAcademyTests : GenericWebDriverTest
    {
        private const string TelerikAcademyBaseUrl = @"http://stage.telerikacademy.com/";

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void RegisterNewAccountWithoutRequiredUsername()
        {
            this.Browser.Navigate().GoToUrl(TelerikAcademyBaseUrl);

            var registerFacade = new RegisterFacade();
            registerFacade.Register(this.Browser, "12345678", "Ася", "Георгиева", "qa@track.com");

            Assert.AreEqual(
                true,
                this.IsElementPresent(By.XPath("//ul/li[text()[contains(., 'Потребителското име е задължително')]]")));
        }

        [TestMethod]
        public void RegisterNewAccountWithAllRequiredFields()
        {
            this.Browser.Navigate().GoToUrl(TelerikAcademyBaseUrl);

            var registerFacade = new RegisterFacade();
            registerFacade.Register(
                this.Browser,
                "12345678",
                "Ася",
                "Георгиева",
                "qa@track.com",
                RandomStringGenerator.Generate(RandomNumberGenerator.Generate(5, 32)));

            Assert.AreEqual(
                false,
                this.IsElementPresent(By.XPath("//ul/li[text()[contains(., 'Потребителското име е задължително')]]")));
        }

        [TestMethod]
        public void RegisterNewAccountWithDisabledJavaScript()
        {
            //var profile = new FirefoxProfile();
            //profile.SetPreference("javascript.enabled", false);
            //this.Browser = new FirefoxDriver(profile);
            this.Browser.Navigate().GoToUrl(TelerikAcademyBaseUrl);

            var registerFacade = new RegisterFacade();
            registerFacade.Register(
                this.Browser,
                "12345678",
                "Ася",
                "Георгиева",
                "qa@track.com",
                RandomStringGenerator.Generate(RandomNumberGenerator.Generate(5, 32)));

            Assert.AreEqual(
                false,
                this.IsElementPresent(By.XPath("//ul/li[text()[contains(., 'Потребителското име е задължително')]]")));
        }
    }
}