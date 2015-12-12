namespace FindZipCodesTests.Pages.ElementMaps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class FindZipPage
    {
        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[1]/table[5]/tbody/tr/td/a[12]"
            )]
        public IWebElement CitiesStartingWithCertainLetterLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[1]"
            )]
        public IWebElement FirstCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement FirstCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement FirstCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement FirstCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement FirstCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement FirstCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[2]"
            )]
        public IWebElement SecondCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement SecondCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement SecondCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement SecondCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement SecondCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement SecondCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[3]"
            )]
        public IWebElement ThirdCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement ThirdCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement ThirdCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement ThirdCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement ThirdCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement ThirdCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[4]"
            )]
        public IWebElement FourthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement FourthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement FourthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement FourthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement FourthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement FourthCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[5]"
            )]
        public IWebElement FifthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement FifthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement FifthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement FifthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement FifthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement FifthCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[6]"
            )]
        public IWebElement SixthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement SixthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement SixthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement SixthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement SixthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement SixthCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[7]"
            )]
        public IWebElement SeventhCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement SeventhCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement SeventhCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement SeventhCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement SeventhCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement SeventhCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[8]"
            )]
        public IWebElement EighthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement EigthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement EigthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement EigthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement EigthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement EigthCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[9]"
            )]
        public IWebElement NinthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement NinthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement NinthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement NinthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement NinthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement NinthCityLatitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[4]/td/a[10]"
            )]
        public IWebElement TenthCityFromListLink { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"
            )]
        public IWebElement TenthCityName { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"
            )]
        public IWebElement TenthCityState { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b/b"
            )]
        public IWebElement TenthCityZipCode { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"
            )]
        public IWebElement TenthCityLongitude { get; set; }

        [FindsBy(How = How.XPath,
            Using =
                "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"
            )]
        public IWebElement TenthCityLatitude { get; set; }
    }
}