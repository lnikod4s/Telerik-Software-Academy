namespace RegistrationTelerikAcademyTests.Pages.Facades
{
    using ElementMaps;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class RegisterFacade
    {
        public void Register(
            IWebDriver browser,
            string password,
            string firstName,
            string lastName,
            string email,
            string username = null)
        {
            var registerPage = new RegisterPage();
            PageFactory.InitElements(browser, registerPage);
            registerPage.RegisterButton.Click();
            registerPage.Username.SendKeys(username);
            registerPage.Password.SendKeys(password);
            registerPage.PasswordAgain.SendKeys(password);
            registerPage.FirstName.SendKeys(firstName);
            registerPage.LastName.SendKeys(lastName);
            registerPage.Email.SendKeys(email);
            registerPage.TermsAndConditions.Click();
            registerPage.SubmitButton.Click();
        }
    }
}