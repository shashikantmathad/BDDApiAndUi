using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Reflection;
using TechTalk.SpecFlow;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace SeleniumUi.Hooks
{
    [Binding]
    public sealed class Setup
    {
        private readonly IObjectContainer objectContainer;
        //private RemoteWebDriver driver;
        private IWebDriver driver;


        // Extent Report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public Setup(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string file = @"Reports\Report.html";
            var path = Path.Combine(solutionPath, file);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            // config = new WebDriverConfig(new Configuration())
            //objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
        }

        //[BeforeScenario]
        //public void RunBeforeScenario()
        //{
        //    //this.objectContainer.RegisterInstanceAs<WebDriverConfig>(config);
        //    this.objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
        //}

        [AfterTestRun]
        public static void AfterScenario()
        {
            extent.Flush();
            //TODO: implement logic that has to run after executing each scenario
            //config.QuitDriver();
        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }


        [BeforeScenario]
        [Obsolete]
        public void Initialize()
        {
            //Create dynamic scenario name
            scenario = featureName.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeScenario]
        public void BrowserSetup()
        {
            SelectBrowser(BrowserType.Chrome);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }

        void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:

                    driver = new ChromeDriver();
                    objectContainer.RegisterInstanceAs<IWebDriver>(driver);
                    //objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
                    break;
                case BrowserType.Frirefox:
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    driver = new FirefoxDriver(service);
                    //objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
                    objectContainer.RegisterInstanceAs<IWebDriver>(driver);
                    break;
                default:
                    break;

            }
        }

        enum BrowserType { Chrome, Frirefox }
    }
}
