using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private DriverHelper _driverHelper;
        private MainPage mainPage;
        private LoginPage loginPage;

        public LoginStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            mainPage = new MainPage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }


        [Given(@"website is opened")]
        public void GivenWebsiteIsOpened()
        {
            mainPage.NavigateToUrl();
        }

        [When(@"user provides credentials")]
        public void WhenUserProvidesCredentials()
        {
            loginPage.loginAsStandardUser();
        }

        [Then(@"is successfuly logged in")]
        public void ThenIsSuccessfulyLoggedIn()
        {
            Assert.That(mainPage.HeaderTitle(), Is.EqualTo("PRODUCTS"));
        }
    }
}
