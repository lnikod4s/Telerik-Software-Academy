namespace TelerikTestingFrameworkHomework
{
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.Xaml.Wpf;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.TestTemplates;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Button = ArtOfTest.WebAii.Controls.Xaml.Wpf.Button;
    using ComboBox = ArtOfTest.WebAii.Controls.Xaml.Wpf.ComboBox;
    using TextBox = ArtOfTest.WebAii.Controls.Xaml.Wpf.TextBox;

    /// <summary>
    ///     Summary description for WpfTests
    /// </summary>
    [TestClass]
    public class WpfTests : BaseWpfTest
    {
        //private const string Vs2013LocationPath =
        //    @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";

        private const string Vs2015LocationPath =
            @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";

        [TestMethod]
        public void CreateUnitTestProjectInVisualStudioTest()
        {
            var app = this.Manager.LaunchNewApplication(new ProcessStartInfo(Vs2015LocationPath));

            app.Manager.ActiveApplication.MainWindow.Find.ByName<TextBlock>("PART_Text")
               .User.Click(MouseClickType.LeftClick);
            app.Manager.ActiveApplication.MainWindow.Find.ByName<TextBlock>("CategoryNameUid")
               .User.Click(MouseClickType.LeftClick);
            app.Manager.ActiveApplication.MainWindow.Find.ByAutomationId<TextBlock>("Test")
               .User.Click(MouseClickType.LeftClick);
            app.Manager.ActiveApplication.MainWindow.Find.ByTextContent("Unit Test Project")
               .User.Click(MouseClickType.LeftClick);

            var projectName = app.Manager.ActiveApplication.MainWindow.Find.ByName<TextBox>("txt_Name");
            projectName.User.Click(MouseClickType.LeftDoubleClick);
            projectName.User.KeyPress(Keys.Delete, 10);
            projectName.User.TypeText("MyUnitTestsProject", 10, true);

            var locationPath = app.Manager.ActiveApplication.MainWindow.Find.ByName<ComboBox>("cmb_Location");
            locationPath.User.Click(MouseClickType.LeftDoubleClick);
            locationPath.User.KeyPress(Keys.Delete, 10);
            locationPath.User.TypeText(@"C:\MyProjects", 10, true);
            app.Manager.ActiveApplication.MainWindow.Find.ByName<Button>("btn_OK").User.Click(MouseClickType.LeftClick);

            // If your machine is slow, please enter another value in Thread.Sleep(int Timeout), e.g. 200000, 300000 etc.
            Thread.Sleep(10000);
            Assert.IsTrue(File.Exists(@"C:\MyProjects\MyUnitTestsProject\MyUnitTestsProject.sln"));

            app.Manager.ActiveApplication.MainWindow.Find.ByName("HideButton").User.Click(MouseClickType.LeftClick);

            Thread.Sleep(10000);
            Directory.Delete(@"C:\MyProjects", true);
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

            this.Initialize(this.TestContext.TestLogsDir, this.TestContext.WriteLine);

            // If you need to override any other settings coming from the
            // config section you can comment the 'Initialize' line above and instead
            // use the following:

            /*

            // This will get a new Settings object. If a configuration
            // section exists, then settings from that section will be
            // loaded

            Settings settings = GetSettings();

            // Override the settings you want. For example:
            settings.WaitCheckInterval = 10000;

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

            // Shuts down WebAii manager and closes all applications currently running
            // after each test.
            this.CleanUp();

            #endregion
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            // This will shut down all applications
            ShutDown();
        }

        #endregion
    }
}