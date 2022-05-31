using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace SpecFlowProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement userNameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement passwordInput => _driver.FindElement(By.Id("password"));
        private IWebElement loginButton => _driver.FindElement(By.Id("login-button"));

        public void LoginAsStandardUser()
        {
            userNameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");
            loginButton.Click();
        }

    }
}
