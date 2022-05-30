using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.Pages
{
    public class MainPage
    {
        public string Url = "https://www.saucedemo.com/";

        private IWebDriver Driver;

        public MainPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
