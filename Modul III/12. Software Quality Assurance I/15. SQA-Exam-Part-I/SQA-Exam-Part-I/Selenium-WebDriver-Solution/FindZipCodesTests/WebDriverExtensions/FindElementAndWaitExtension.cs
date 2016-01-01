namespace FindZipCodesTests.WebDriverExtensions
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class FindElementAndWaitExtension
    {
        private static WebDriverWait internalWait;

        public static IWebElement FindElementAndWait(this IWebDriver driver, By findExpression)
        {
            if (internalWait == null)
            {
                internalWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            }

            var element = internalWait.Until(x => x.FindElement(findExpression));
            return element;
        }
    }
}