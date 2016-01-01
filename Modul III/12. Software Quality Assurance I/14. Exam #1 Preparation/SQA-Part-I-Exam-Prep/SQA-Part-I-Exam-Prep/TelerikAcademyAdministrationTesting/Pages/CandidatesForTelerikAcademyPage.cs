namespace TelerikAcademyAdministrationTesting.Pages
{

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class CandidatesForTelerikAcademyPage
    {
        private const string CandidatesForTelerikAcademyUrl =
            LoginPage.BaseTelerikAcademyUrl + "Administration/Navigation";

        [FindsBy(How = How.XPath, Using = "//*[@id=\"QaTestingTool\"]/form/fieldset/input[1]")]
        public IWebElement DeleteCandidateField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"QaTestingTool\"]/form/fieldset/input[2]")]
        public IWebElement DeleteCandidateButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id=\"DeletedCandidates\"]")]
        //public IWebElement DeletedCandidacyConfirmation { get; set; }

        public void Navigate(IWebDriver browser)
        {
            browser.Navigate().GoToUrl(CandidatesForTelerikAcademyUrl);
            var adminPanelPage = new MainAdminPanelPage();
            PageFactory.InitElements(browser, adminPanelPage);
            adminPanelPage.CandidatesForTelerikAcademyLink.Click();
        }

        public void VerifyExistenceOfCandidacy(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.DeleteCandidateField.Clear();
            this.DeleteCandidateField.SendKeys("lyudmil.nikodimov@gmail.com");
            this.DeleteCandidateButton.Click();
            //Assert.AreEqual(true, this.DeletedCandidacyConfirmation.Text.EndsWith("lyudmil.nikodimov@gmail.com"));
        }
    }
}