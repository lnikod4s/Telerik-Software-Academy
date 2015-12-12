namespace TelerikAcademyAdministrationTesting.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class MainNavigationPage
    {
        [FindsBy(How = How.Id, Using = "EntranceButton")]
        public IWebElement YourAccountLink { get; set; }
    }
}