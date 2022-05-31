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

        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement header => _driver.FindElement(By.CssSelector(".title"));

        public void NavigateToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public string HeaderTitle()
        {
            return header.Text;
        }
    }
}
