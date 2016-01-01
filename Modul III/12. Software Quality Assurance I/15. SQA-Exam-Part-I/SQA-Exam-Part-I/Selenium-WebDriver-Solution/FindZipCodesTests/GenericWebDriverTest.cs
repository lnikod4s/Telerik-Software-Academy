namespace FindZipCodesTests
{
    using System;
    using System.Reflection;
    using System.Text;

    using CustomExceptions;

    using log4net;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;

    using NoSuchElementException = CustomExceptions.NoSuchElementException;

    [TestClass]
    public class GenericWebDriverTest
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver Browser { get; set; }

        public StringBuilder VerificationErrors { get; set; }

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

        [TestInitialize]
        public void SetupTest()
        {
            this.Browser = new FirefoxDriver();
            this.Browser.Manage().Window.Maximize();
            this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(10));
            this.TimeOut = 1000;
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                this.Browser.Quit();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public IWebElement GetElement(By by)
        {
            IWebElement result;
            try
            {
                result = this.Wait.Until(x => x.FindElement(by));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw new NoSuchElementException(by, this, ex);
            }

            return result;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                this.Browser.FindElement(by);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public void WaitForElementPresent(By by)
        {
            this.GetElement(by);
        }

        public void WaitForElementNotPresent(By by)
        {
            try
            {
                this.GetElement(by);
                throw new ElementStillVisibleException(by, this);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public void WaitForChecked(By by)
        {
            var currentElement = this.GetElement(by);
            var isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Logger.ErrorFormat("The element with find expression {0} was not checked.", @by);
                throw new NotCheckedException(by, this);
            }
        }

        public void WaitForNotChecked(By by)
        {
            var currentElement = this.GetElement(by);
            var isSelected = currentElement.Selected;

            if (!isSelected)
            {
                Logger.ErrorFormat("The element with find expression {0} was checked.", @by);
                throw new StillCheckedException(by, this);
            }
        }

        public void WaitForText(By by, string textToFind)
        {
            var currentElement = this.GetElement(by);
            var elementText = currentElement.Text;

            if (!textToFind.Equals(elementText))
            {
                Logger.ErrorFormat("The following text: {0}\n was not found on the page.", textToFind);
                throw new TextNotFoundException(textToFind, this);
            }
        }
    }
}