namespace FindZipCodesTests.Pages.ElementMaps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class GoogleMapsPage
    {
        [FindsBy(How = How.Id, Using = "searchboxinput")]
        public IWebElement SearchBoxInputField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='searchbox']/div[1]/button")]
        public IWebElement SearchButton { get; set; }
    }
}