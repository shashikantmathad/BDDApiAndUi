using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumUi.Utilities
{
    public class CommonLibraries
    {
        // private  readonly RemoteWebDriver _driver;
        private readonly IWebDriver _driver;
        private WebDriverWait wait;
        // public CommonLibraries(RemoteWebDriver driver) => _driver = driver;
        public CommonLibraries(IWebDriver driver) => _driver = driver;

        public void GetHomePage(String URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public void WebdriverExplicitWait(double waitTime)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
            }
            catch (TimeoutException e)
            {
                Assert.Fail(e.Message);
            }
        }

        public void WaitUntilWebElementIsVisible(IWebElement waitElement)
        {
            try
            {
                wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
                {
                    return waitElement;
                });
                wait.Until(waitForElement);
            }
            catch (TimeoutException e)
            {
                Assert.Fail("WebElement is not visible, Exception: {0}", e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
