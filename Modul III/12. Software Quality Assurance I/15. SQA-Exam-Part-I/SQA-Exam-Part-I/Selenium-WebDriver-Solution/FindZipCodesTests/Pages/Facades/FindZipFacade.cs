namespace FindZipCodesTests.Pages.Facades
{
    using ElementMaps;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class FindZipFacade
    {
        public void OpenListWithCities(IWebDriver browser)
        {
            var findZipPage = new FindZipPage();
            PageFactory.InitElements(browser, findZipPage);
            findZipPage.CitiesStartingWithCertainLetterLink.Click();
            findZipPage.FirstCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.SecondCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.ThirdCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.FourthCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.FifthCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.SixthCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.SeventhCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.EighthCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.NinthCityFromListLink.Click();
            browser.Navigate().Back();
            findZipPage.TenthCityFromListLink.Click();
            browser.Navigate().Back();
        }
    }
}