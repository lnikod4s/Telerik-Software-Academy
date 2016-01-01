namespace TelerikAcademyAdministrationTesting
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;

    using Pages;

    [TestClass]
    public class TelerikAcademyAdministrationTests : GenericWebDriverTest
    {
        [TestInitialize]
        public void SetupTest()
        {
            this.Browser = new FirefoxDriver();
            this.Browser.Manage().Window.Maximize();
            this.Browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            this.BaseUrl = @"http://stage.telerikacademy.com/";
            this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(10));
            this.TimeOut = 10;
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Browser.Quit();
        }

        [TestMethod]
        public void LoginTelerikAcademyTest()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate(this.Browser);
            loginPage.LoginUser(this.Browser);
        }

        [TestMethod]
        public void ApplyForTelerikAcademySeasonTest()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate(this.Browser);
            loginPage.LoginUser(this.Browser);

            var applyForTelerikAcademyPage = new ApplyForTelerikAcademyPage();
            applyForTelerikAcademyPage.Navigate(this.Browser);
            applyForTelerikAcademyPage.FillRequiredFieldsData(this.Browser);
        }

        [TestMethod]
        public void DeleteCandidateTest()
        {
            var loginPage = new LoginPage();
            loginPage.Navigate(this.Browser);
            loginPage.LoginUser(this.Browser);

            var candidatesForTelerikAcademyPage = new CandidatesForTelerikAcademyPage();
            candidatesForTelerikAcademyPage.Navigate(this.Browser);
            candidatesForTelerikAcademyPage.VerifyExistenceOfCandidacy(this.Browser);
        }
    }
}