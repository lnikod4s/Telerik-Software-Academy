namespace TelerikAcademyAdministrationTesting
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class GenericWebDriverTest
    {
        public IWebDriver Browser { get; set; }

        public string BaseUrl { get; set; }

        public WebDriverWait Wait { get; set; }

        public IWebElement CurrentElement { get; set; }

        public int TimeOut { get; set; }

        public void TestInit(IWebDriver driver, string baseUrl, int timeOut)
        {
            this.Browser = driver;
            this.BaseUrl = baseUrl;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            this.TimeOut = timeOut;
        }

        public IWebElement GetElement(By by)
        {
            return this.Wait.Until(x => x.FindElement(by));
        }

        public bool IsElementPresent(By by)
        {
            return this.Browser.FindElement(by).Displayed;
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }
    }
}