using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private static readonly string _pathToTestOutputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestOutput");


        public Hooks(DriverHelper driverHelper, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (Directory.Exists(_pathToTestOutputFolder))
            {
                Directory.Delete(_pathToTestOutputFolder, true);
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            _driverHelper.Driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SaveScreenshot();
            _driverHelper.Driver.Quit();
        }

        private void SaveScreenshot()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    Screenshot ss = ((ITakesScreenshot)_driverHelper.Driver).GetScreenshot();
                    string featureTitle = string.Concat(_featureContext.FeatureInfo.Title, "Feature");
                    string scenarioTitle = _scenarioContext.ScenarioInfo.Title;
                    string fullScreenshotName = string.Concat(scenarioTitle, "-", DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss"), ".png");
                    if (!Directory.Exists(_pathToTestOutputFolder))
                    {
                        Directory.CreateDirectory(Path.Combine(_pathToTestOutputFolder, featureTitle));
                    }
                    ss.SaveAsFile(Path.Combine(_pathToTestOutputFolder, featureTitle, fullScreenshotName), ScreenshotImageFormat.Png);
                }
            }
            catch
            {
                //Console.WriteLine("catch");   
            }

        }
    }
}