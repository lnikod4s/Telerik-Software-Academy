namespace TelerikTestingFrameworkHomework
{
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Summary description for KendoDemosTest
    /// </summary>
    [TestClass]
    public class WebTests : BaseTest
    {
        [TestMethod]
        public void VerifyThatCorrectPagesAreLoadedTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("https://www.google.com/");

            var searchField = this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("lst-ib");
            this.Manager.Desktop.Mouse.Click(MouseClickType.LeftClick, Rectangle.Round(searchField.GetRectangle()));
            searchField.Text = "Telerik Testing Framework";
            this.Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);

            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var firstResult =
                this.Manager.ActiveBrowser.Find.AllByExpression<HtmlAnchor>(
                    "textcontent=Telerik free software testing framework").FirstOrDefault();
            Assert.AreEqual("http://www.telerik.com/teststudio/testing-framework", firstResult.Attributes[1].Value);

            firstResult.Click();

            this.Manager.ActiveBrowser.WaitUntilReady();
            this.Manager.ActiveBrowser.Find.ById<HtmlAnchor>("GeneralContent_C002_ctl00_ctl00_TryNowHyperLink").Click();

            this.Manager.ActiveBrowser.WaitUntilReady();
            Assert.AreEqual("http://www.telerik.com/download/testing-framework", this.ActiveBrowser.Url);
        }

        [TestMethod]
        public void LaunchKendoUiDemosTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://www.telerik.com/support/demos");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("textcontent=Launch Kendo UI demos").Click();
            this.Manager.ActiveBrowser.WaitUntilReady();
            Assert.AreEqual("http://demos.telerik.com/kendo-ui/", this.Manager.ActiveBrowser.Url);

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("href=/kendo-ui/grid/index", "textcontent=Grid")
                .Click();
            this.Manager.ActiveBrowser.WaitUntilReady();
            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "href=/kendo-ui/grid/from-table",
                "textcontent=Initialization from table").Click();
            this.Manager.ActiveBrowser.WaitUntilReady();

            var grid = this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("exampleWrap");
            Assert.AreEqual(true, grid.IsVisible());

            this.Manager.ActiveBrowser.RefreshDomTree();
            var rows = this.Manager.ActiveBrowser.Find.AllByExpression("class=k-header").Count;
            var columns = this.Manager.ActiveBrowser.Find.AllByExpression("role=row").Count - 1;
            Assert.AreEqual(5, rows);
            Assert.AreEqual(21, columns);
        }

        [TestMethod]
        public void KendoUiSortingCarMakeByAscendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("class=k-link", "textcontent=Car Make").Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Alfa Romeo", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingCarMakeByDescendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var carNameHeader = this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "class=k-link",
                "textcontent=Car Make");
            carNameHeader.Click();
            carNameHeader.Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("VW", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingCarModelByAscendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("class=k-link", "textcontent=Car Model").Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Alfa Romeo", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingCarModelByDescendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var carNameHeader = this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "class=k-link",
                "textcontent=Car Model");
            carNameHeader.Click();
            carNameHeader.Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Lancia", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingYearByAscendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("class=k-link", "textcontent=Year").Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Nissan", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingYearByDescendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var carNameHeader = this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "class=k-link",
                "textcontent=Year");
            carNameHeader.Click();
            carNameHeader.Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Hyundai", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingCategoryByAscendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("class=k-link", "textcontent=Category").Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Mercedez", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingCategoryByDescendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var carNameHeader = this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "class=k-link",
                "textcontent=Category");
            carNameHeader.Click();
            carNameHeader.Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Audi", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingAirConditionerByAscendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("class=k-link", "textcontent=Air Conditioner")
                .Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("BMW", firstGridCellContent.InnerText);
        }

        [TestMethod]
        public void KendoUiSortingAirConditionerByDescendingTest()
        {
            this.Manager.LaunchNewBrowser();
            this.Manager.ActiveBrowser.Window.Maximize();
            this.Manager.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/grid/from-table");

            this.Manager.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(1000);
            this.Manager.ActiveBrowser.RefreshDomTree();

            var carNameHeader = this.Manager.ActiveBrowser.Find.ByExpression<HtmlAnchor>(
                "class=k-link",
                "textcontent=Air Conditioner");
            carNameHeader.Click();
            carNameHeader.Click();

            this.Manager.ActiveBrowser.RefreshDomTree();
            var firstGridCellContent = this.Manager.ActiveBrowser.Find.ByExpression<HtmlTableCell>("role=gridcell");
            Assert.AreEqual("Volvo", firstGridCellContent.InnerText);
        }

        #region [Setup / TearDown]

        /// <summary>
        ///     Gets or sets the VS test context which provides
        ///     information about and functionality for the
        ///     current test run.
        /// </summary>
        public TestContext TestContext { get; set; } = null;

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
            #region WebAii Initialization

            // Initializes WebAii manager to be used by the test case.
            // If a WebAii configuration section exists, settings will be
            // loaded from it. Otherwise, will create a default settings
            // object with system defaults.
            //
            // Note: We are passing in a delegate to the VisualStudio
            // testContext.WriteLine() method in addition to the Visual Studio
            // TestLogs directory as our log location. This way any logging
            // done from WebAii (i.e. Manager.Log.WriteLine()) is
            // automatically logged to the VisualStudio test log and
            // the WebAii log file is placed in the same location as VS logs.
            //
            // If you do not care about unifying the log, then you can simply
            // initialize the test by calling Initialize() with no parameters;
            // that will cause the log location to be picked up from the config
            // file if it exists or will use the default system settings (C:\WebAiiLog\)
            // You can also use Initialize(LogLocation) to set a specific log
            // location for this test.

            // Pass in 'true' to recycle the browser between test methods
            this.Initialize(true, this.TestContext.TestLogsDir, this.TestContext.WriteLine);

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.Web.DefaultBrowser = BrowserType.FireFox;

            // Now call Initialize again with your updated settings object
            Initialize(settings, new TestContextWriteLine(this.TestContext.WriteLine));

            */

            // Set the current test method. This is needed for WebAii to discover
            // its custom TestAttributes set on methods and classes.
            // This method should always exist in [TestInitialize()] method.
            this.SetTestMethod(this, (string)this.TestContext.Properties["TestName"]);

            #endregion

            //
            // Place any additional initialization here
            //
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            //
            // Place any additional cleanup here
            //

            #region WebAii CleanUp

            // Shuts down WebAii manager and closes all browsers currently running
            // after each test. This call is ignored if recycleBrowser is set
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            // This will shut down all browsers if
            // recycleBrowser is turned on. Else
            // will do nothing.
            ShutDown();
        }

        #endregion
    }
}