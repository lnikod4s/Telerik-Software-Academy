namespace TelerikTestingFramework
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Summary description for TelerikAcademyTests
    /// </summary>
    [TestClass]
    public class TelerikAcademyTests : BaseTest
    {
        [TestMethod]
        public void SearchInActiveBrowser()
        {
            this.Manager.LaunchNewBrowser();
            this.ActiveBrowser.NavigateTo("http://telerikacademy.com/");
            this.ActiveBrowser.RefreshDomTree();

            var searchField = this.Find.ById<HtmlInputControl>("SearchTerm");
            searchField.MouseClick();
            this.Manager.Desktop.KeyBoard.TypeText("XAML");

            var searchButton = this.Find.ById<HtmlInputSubmit>("SearchButton");
            searchButton.MouseClick();

            //var coursesPanel =
            //    this.Find.AllByAttributes<HtmlDiv>("class=panel panel-success")
            //        .FirstOrDefault(p => p.Find.AllByTagName("tagname=h3").FirstOrDefault().InnerText == "Курсове");
            //var courseResults = coursesPanel.Find.AllByExpression("class=?SearchResult");

            //Assert.AreEqual(4, courseResults.Count);

            //var tracksPanel =
            //    this.Find.AllByAttributes<HtmlDiv>("class=panel panel-success")
            //        .FirstOrDefault(p => p.Find.AllByTagName("tagname=h3").FirstOrDefault().InnerText == "Тракове");
            //var trackResults = tracksPanel.Find.AllByExpression("class=?SearchResult");

            //Assert.AreEqual(4, trackResults.Count);
        }

        [TestMethod]
        public void InvalidLogin()
        {
            this.Manager.LaunchNewBrowser();
            this.ActiveBrowser.NavigateTo("http://telerikacademy.com/");
            this.ActiveBrowser.WaitUntilReady();
            this.ActiveBrowser.RefreshDomTree();

            this.Find.ById<HtmlAnchor>("EntranceButton").Click();
            this.Find.ById<HtmlInputText>("UsernameOrEmail").Text = "fakeuser";
            this.Find.ById<HtmlInputPassword>("Password").Text = "password";
            this.Find.ByExpression<HtmlInputSubmit>("tagname=input", "value=Вход").Click();
            var validationSummaryError = this.Find.ByAttributes<HtmlDiv>("class=validation-summary-errors");
            Assert.AreEqual(true, validationSummaryError.IsVisible());
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
            //foreach (var process in Process.GetProcessesByName("vstest.exe"))
            //{
            //    process.Kill();
            //}

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