using SeleniumUi.Pages;
using SeleniumUi.Utilities;
using NUnit.Framework;
//using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using OpenQA.Selenium;


namespace SeleniumUi.Steps
{
    [Binding]
    public sealed class SharedSteps
    {
        // private readonly RemoteWebDriver driver;
        private readonly IWebDriver driver;
        private readonly CommonLibraries methods;
        // public SharedSteps(RemoteWebDriver driver)
        public SharedSteps(IWebDriver driver)
        {
            this.driver = driver;
            methods = new CommonLibraries(driver);
        }

        [Given(@"I Navigate to '(.*)'")]
        public void GivenINavigateTo(string URL)
        {
            try
            {
                methods.GetHomePage(URL);
                methods.WebdriverExplicitWait(30);
                Assert.True(true, "User has navigated to home page");
                Debug.WriteLine("User has navigated to home page");
            }
            catch (Exception e)
            {
                Assert.Fail("User is unable to navigate to home page, Exception: {0}", e.Message);
            }
        }

        [Then(@"the page '(.*)' is displayed")]
        public void ThenThePageIsDisplayed(string expectedResult)
        {
            try
            {
                String actaulResult = driver.Title;
                Assert.That(actaulResult, Is.EqualTo(expectedResult));
                Assert.True(true, "Title has verified successfully");
                Debug.WriteLine("Title has verified successfully");
            }
            catch (Exception e)
            {
                Assert.Fail("Wrong tilte is displaying, Exception: ", e.Message);
            }

        }

        [Then(@"I have Navigated to '(.*)'")]
        public void GivenIHaveOpenedTheHomePage(string URL)
        {
            try
            {
                methods.GetHomePage(URL);
                Assert.True(true, "User navigated to page");
                Debug.WriteLine("User navigated to page");
            }
            catch (Exception e)
            {
                Assert.Fail("User is unable to navigate to page, Exception: {0}", e.Message);
            }
        }

    }
}
