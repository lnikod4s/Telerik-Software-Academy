namespace FindZipCodesTests
{
    using System.Drawing.Imaging;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using Pages.ElementMaps;
    using Pages.Facades;

    [TestClass]
    public class FindZipCodeTests : GenericWebDriverTest
    {
        private const string FindZipCodeBaseUrl = "http://wwww.findazip.com/";

        private const string GoogleMapsBaseUrl = "https://maps.google.com/";

        [TestMethod]
        public void OpenListWithCitiesWithChosenFirstLetter()
        {
            this.Browser.Navigate().GoToUrl(FindZipCodeBaseUrl);
            var findZipFacade = new FindZipFacade();
            findZipFacade.OpenListWithCities(this.Browser);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForFirstCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.FirstCityLatitude.Text,
                findZipPage.FirstCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.FirstCityName.Text + "-" + findZipPage.FirstCityState.Text + "-"
                + findZipPage.FirstCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForSecondCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.SecondCityLatitude.Text,
                findZipPage.SecondCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.SecondCityName.Text + "-" + findZipPage.SecondCityState.Text + "-"
                + findZipPage.SecondCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForThirdCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.ThirdCityLatitude.Text,
                findZipPage.ThirdCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.ThirdCityName.Text + "-" + findZipPage.ThirdCityState.Text + "-"
                + findZipPage.ThirdCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForFourthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.FourthCityLatitude.Text,
                findZipPage.FourthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.FourthCityName.Text + "-" + findZipPage.FourthCityState.Text + "-"
                + findZipPage.FourthCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForFifthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.FifthCityLatitude.Text,
                findZipPage.FifthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.FifthCityName.Text + "-" + findZipPage.FifthCityState.Text + "-"
                + findZipPage.FifthCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForSixthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.SixthCityLatitude.Text,
                findZipPage.SixthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.SixthCityName.Text + "-" + findZipPage.SixthCityState.Text + "-"
                + findZipPage.SixthCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForSeventhCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.SeventhCityLatitude.Text,
                findZipPage.SeventhCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.SeventhCityName.Text + "-" + findZipPage.SeventhCityState.Text + "-"
                + findZipPage.SeventhCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForEigthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.EigthCityLatitude.Text,
                findZipPage.EigthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.EigthCityName.Text + "-" + findZipPage.EigthCityState.Text + "-"
                + findZipPage.EigthCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForNinthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.NinthCityLatitude.Text,
                findZipPage.NinthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.NinthCityName.Text + "-" + findZipPage.NinthCityState.Text + "-"
                + findZipPage.NinthCityZipCode.Text,
                ImageFormat.Jpeg);
        }

        [TestMethod]
        public void GenerateGoogleMapsLinkForTenthCity()
        {
            this.Browser.Navigate().GoToUrl(GoogleMapsBaseUrl);
            var findZipPage = new FindZipPage();
            var googleMapsFacade = new GoogleMapsFacade();
            googleMapsFacade.SearchCityByLongitudeAndLatitude(
                this.Browser,
                findZipPage.TenthCityLatitude.Text,
                findZipPage.TenthCityLongitude.Text);
            var currentScreenshot = ((ITakesScreenshot)this.Browser).GetScreenshot();
            currentScreenshot.SaveAsFile(
                findZipPage.TenthCityName.Text + "-" + findZipPage.TenthCityState.Text + "-"
                + findZipPage.TenthCityZipCode.Text,
                ImageFormat.Jpeg);
        }
    }
}