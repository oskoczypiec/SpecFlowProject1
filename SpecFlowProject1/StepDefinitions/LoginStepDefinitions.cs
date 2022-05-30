using System;
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
        public LoginStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            mainPage = new MainPage(_driverHelper.Driver);
        }


        [Given(@"website is opened")]
        public void GivenWebsiteIsOpened()
        {
            mainPage.NavigateToUrl();
        }

        [When(@"user provides credentials")]
        public void WhenUserProvidesCredentials()
        {
            throw new PendingStepException();
        }

        [Then(@"is successfuly logged in")]
        public void ThenIsSuccessfulyLoggedIn()
        {
            throw new PendingStepException();
        }
    }
}
