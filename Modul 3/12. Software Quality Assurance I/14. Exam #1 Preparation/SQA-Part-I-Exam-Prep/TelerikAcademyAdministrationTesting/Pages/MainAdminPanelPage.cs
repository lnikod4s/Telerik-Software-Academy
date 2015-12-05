namespace TelerikAcademyAdministrationTesting.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class MainAdminPanelPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"Menu\"]/li[8]/a")]
        public IWebElement CandidatesForTelerikAcademyLink { get; set; }
    }
}