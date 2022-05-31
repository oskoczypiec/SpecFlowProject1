using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1.Support
{
    [Binding]
    public sealed class Hooks1
    {
        private DriverHelper _driverHelper;
        public Hooks1(DriverHelper driverHelper) => _driverHelper = driverHelper;

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
            _driverHelper.Driver.Quit();
        }
    }
}