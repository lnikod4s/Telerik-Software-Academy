namespace TelerikAcademyAdministrationTesting.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class LoginPage
    {
        public const string BaseTelerikAcademyUrl = @"http://stage.telerikacademy.com/";

        [FindsBy(How = How.Id, Using = "UsernameOrEmail")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"MainContent\"]/div/div[2]/form/fieldset/div[3]/input")]
        public IWebElement LoginButton { get; set; }

        public void Navigate(IWebDriver browser)
        {
            browser.Navigate().GoToUrl(BaseTelerikAcademyUrl);
            var navigation = new MainNavigationPage();
            PageFactory.InitElements(browser, navigation);
            navigation.YourAccountLink.Click();
        }

        public void LoginUser(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.UserName.Clear();
            this.UserName.SendKeys("lnikod4s");
            this.Password.Clear();
            this.Password.SendKeys("student");
            this.LoginButton.Click();
        }
    }
}