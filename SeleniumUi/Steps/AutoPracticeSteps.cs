using SeleniumUi.Pages;
using SeleniumUi.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;


namespace SeleniumUi.Steps
{
    [Binding]
    public sealed class AutoPracticeSteps
    {
        private readonly IWebDriver driver;
        private readonly AutoPracticePage autoPracticePage;
        public AutoPracticeSteps(IWebDriver driver)
        {
            this.driver = driver;
            autoPracticePage = new AutoPracticePage(driver);
        }

        [Then(@"I Click on Sign In Button")]
        public void ThenIClickOnSignInButton()
        {
            autoPracticePage.ClickonSignInButton();

        }


        [Then(@"I Register New User")]
        public void ThenIRegisterNewUser()
        {
            {
                autoPracticePage.RegisterNewUser();
            }
        }


    }
}
