namespace TelerikAcademyAdministrationTesting.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class ApplyForTelerikAcademyPage
    {
        private const string ApplyForTelerikAcademyUrl = LoginPage.BaseTelerikAcademyUrl + "SoftwareAcademy/Candidate";

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "SecondName")]
        public IWebElement SecondName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "Picture")]
        public IWebElement Picture { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PersonalData\"]/div[8]/span[1]/span/span[1]")]
        public IWebElement Status { get; set; }

        [FindsBy(How = How.Id, Using = "BirthDay")]
        public IWebElement BirthDay { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "Phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PersonalData\"]/div[16]/span[1]/span/span[1]")]
        public IWebElement HomeTown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PersonalData\"]/div[18]/span[1]/span/span[1]")]
        public IWebElement University { get; set; }

        [FindsBy(How = How.Id, Using = "SchoolName")]
        public IWebElement School { get; set; }

        [FindsBy(How = How.Id, Using = "CV")]
        public IWebElement Cv { get; set; }

        [FindsBy(How = How.Id, Using = "CoverLetter")]
        public IWebElement CoverLetter { get; set; }

        [FindsBy(How = How.Id, Using = "AcceptTerms")]
        public IWebElement AcceptTerms { get; set; }

        [FindsBy(How = How.Id, Using = "SendButton")]
        public IWebElement SubmitButton { get; set; }

        public void Navigate(IWebDriver browser)
        {
            browser.Navigate().GoToUrl(ApplyForTelerikAcademyUrl);
        }

        public void FillRequiredFieldsData(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.FirstName.Clear();
            this.FirstName.SendKeys("Людмил");
            this.SecondName.Clear();
            this.SecondName.SendKeys("Ненчев");
            this.LastName.Clear();
            this.LastName.SendKeys("Никодимов");
            this.Picture.Clear();
            this.Picture.SendKeys(@"C:\Users\Lyudmil\Downloads\Profilfoto.jpg");
            this.Status.Click();
            this.BirthDay.Clear();
            this.BirthDay.SendKeys("19/03/1986");
            this.Email.Clear();
            this.Email.SendKeys("lyudmil.nikodimov@gmail.com");
            this.Phone.Clear();
            this.Phone.SendKeys("+359895647562");
            this.HomeTown.Click();
            this.University.Click();
            this.School.Clear();
            this.School.SendKeys("МГ \"Гео Милев\" Плевен");
            this.Cv.Clear();
            this.Cv.SendKeys(@"C:\Users\Lyudmil\Downloads\Exam Preparation.docx");
            this.CoverLetter.Clear();
            this.CoverLetter.SendKeys(@"C:\Users\Lyudmil\Downloads\Exam Preparation.docx");
            this.AcceptTerms.Click();
            this.SubmitButton.Click();
        }
    }
}