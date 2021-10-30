using NUnit.Framework;
//using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using SeleniumUi.Utilities;
using SeleniumUi.Pages;
using System.Diagnostics;
using OpenQA.Selenium;

namespace SeleniumUi.Steps
{
    [Binding]
    public sealed class AirAisaSteps
    {
        private readonly IWebDriver driver;
        private readonly AirAsiaHomePage airAsiaHomePage;
        public AirAisaSteps(IWebDriver driver)
        {
            this.driver = driver;
            airAsiaHomePage = new AirAsiaHomePage(driver);
        }

        [Given(@"Click on Flights Icon")]
        public void GivenClickOnFlightsIcon()
        {
            airAsiaHomePage.ClickonFlights();
        }
        [Then(@"Enter Details And Search Flights")]
        public void ThenEnterDetailsAndSearchFlights()
        {
            airAsiaHomePage.EnterDetailsAndSearchFlights();
        }

        [Then(@"I Click on Login button")]
        public void ThenIClickOnLoginButton()
        {
            airAsiaHomePage.ClickOnLoginBtn();
        }


        [Then(@"Enter Mobile number '(.*)'")]
        public void ThenEnterMobileNum(String IntMobileNum)
        {
            airAsiaHomePage.EnterMobileNum(IntMobileNum);
        }

        [Then(@"Validate Login Window Panel with required header and links")]
        public void ThenValidateLoginWindowPanelWithRequiredHeaderAndLinks()
        {
            airAsiaHomePage.ValidateLoginDialog();
        }



        //[Then(@"Validate Login Error Message")]
        //public void ThenValidateLoginErrorMessage()
        //{
        //    airAsiaHomePage.ValidateLoginError();
        //}

    }
}
