using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement userNameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement passwordInput => _driver.FindElement(By.Id("password"));
        private IWebElement loginButton => _driver.FindElement(By.Id("login-button"));

        public void loginAsStandardUser()
        {
            userNameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");
            loginButton.Click();
        }

    }
}
