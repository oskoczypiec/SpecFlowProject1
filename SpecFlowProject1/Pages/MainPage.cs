using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{
    public class MainPage
    {
        public string Url = "https://www.saucedemo.com/";

        private readonly IWebDriver _driver;

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
