namespace FindZipCodesTests.Pages.Facades
{
    using ElementMaps;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class GoogleMapsFacade
    {
        public void SearchCityByLongitudeAndLatitude(IWebDriver browser, string longitude, string latitude)
        {
            var googleMapsPage = new GoogleMapsPage();
            PageFactory.InitElements(browser, googleMapsPage);
            googleMapsPage.SearchBoxInputField.SendKeys(longitude + ", " + latitude);
            googleMapsPage.SearchButton.Click();
        }
    }
}