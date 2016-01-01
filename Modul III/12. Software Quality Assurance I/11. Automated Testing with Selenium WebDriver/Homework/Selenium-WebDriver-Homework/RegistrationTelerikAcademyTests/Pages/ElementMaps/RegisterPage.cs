namespace RegistrationTelerikAcademyTests.Pages.ElementMaps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class RegisterPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='HeaderLoginPanel']/a")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordAgain")]
        public IWebElement PasswordAgain { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "TermsAndConditions")]
        public IWebElement TermsAndConditions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent']/div/div/div/form/fieldset/div[8]/div/input")]
        public IWebElement SubmitButton { get; set; }
    }
}