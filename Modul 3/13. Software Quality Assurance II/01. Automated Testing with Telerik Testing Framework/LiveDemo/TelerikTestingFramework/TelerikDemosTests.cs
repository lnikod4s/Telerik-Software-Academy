namespace TelerikTestingFramework
{
    using System;
    using System.Globalization;
    using System.Threading;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     Summary description for TelerikDemosTests
    /// </summary>
    [TestClass]
    public class TelerikDemosTests : BaseTest
    {
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
            this.Initialize(false, this.TestContext.TestLogsDir, this.TestContext.WriteLine);

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

        [TestMethod]
        public void DateTimePickerIsCorrectlyChangedAfterAddingNewDate()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.Manager.LaunchNewBrowser();
            this.ActiveBrowser.NavigateTo("http://demos.telerik.com/kendo-ui/datetimepicker/index/");
            this.ActiveBrowser.Window.Maximize();
            this.ActiveBrowser.WaitUntilReady();

            var datetimePickerText = this.Find.ById<HtmlInputText>("datetimepicker").Text;
            var now = DateTime.Now;
            //Assert.AreEqual(datetimePickerText, now.ToString("M/d/yyyy h:mm tt"));

            var selectDateButton = this.Find.ByXPath<HtmlSpan>("//*[@id='example']/div/span/span/span/span[1]");
            selectDateButton.Click();
            var selectedDate =
                this.Find.ByXPath<HtmlAnchor>(
                    "//*[@id='0730e396 - c6c8 - 4556 - 8402 - 486a45a294b1']/table/tbody/tr[2]/td[5]/a");
            selectedDate.Click();

            datetimePickerText = this.Find.ById<HtmlInputText>("datetimepicker").Text;
            //var newText = now.AddDays(1).ToString("M/d/yyyy h:mm tt");
            //Assert.AreEqual(newText, datetimePickerText);
        }
    }
}