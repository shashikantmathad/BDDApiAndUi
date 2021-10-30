using SeleniumUi.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Remote;
using System;
using System.Threading;

using OpenQA.Selenium.Support.UI;

namespace SeleniumUi.Pages
{
    class AirAsiaHomePage
    {
        // private readonly RemoteWebDriver driver;
        private readonly IWebDriver driver;
        private readonly CommonLibraries methods;
        public AirAsiaHomePage(IWebDriver driver)
        {
            this.driver = driver;
            methods = new CommonLibraries(driver);
        }

        //IWebElement txtDepartDate => driver.FindElementByXPath("//input[@aria-label='Depart date']");
        //IWebElement oneway => driver.FindElementByXPath("//div[text()='One way']");
        //IWebElement confirm_btn => driver.FindElementByXPath("//div[text()='Confirm']");
        //IWebElement txtReturnDate => driver.FindElementByXPath("//input[@aria-label='Return date']");
        //IWebElement btnSearch => driver.FindElementByXPath("(//div[text()='Search'])[1]");
        //IWebElement txtUserEmailID => driver.FindElementById("text-input--login");
        //IWebElement txtUserPassword => driver.FindElementById("password-input--login");
        //IWebElement btnLogin => driver.FindElementById("loginbutton");
        //IWebElement eleLoginErrorMsg => driver.FindElementByXPath("//div[@id='aaw-error']//a/ancestor::div[1]");
        //    //"Your log in attempts has been unsuccessful.As a security measure, we’ve locked your account and you’re required to");

        //IWebElement SearchInput => driver.FindElementById("search-input-tool-header");
        //IWebElement CookiesPanel => driver.FindElementByXPath("//span[@id='cookieconsent:desc']");
        //IWebElement AgreeButton => driver.FindElementByXPath("//span[@id='cookieconsent:desc']/following-sibling::div/a[contains(text(), 'Agree')]");
        //IWebElement WhatWeDoLink => driver.FindElementByXPath("//li[contains(@class, 'menu-item top-level')]/a[@title='What we do']");
        //IWebElement LinkFundSolutions => driver.FindElementByXPath("//li[contains(@class, 'menu-item')]/a[contains(text(), 'Link Fund Solutions')]");

        //IWebElement notification_panel => driver.FindElementByCssSelector("div[class='wzrk-alert wiz-show-animate']");             
        //IWebElement deny_promos => driver.FindElementById("wzrk-cancel");


        IWebElement BtnFlights => driver.FindElement(By.XPath("//IMG[@class='flight-search-icon']"));
        IWebElement TxtFromCity => driver.FindElement(By.XPath("//DIV[@class='flight-search-source-code'][text()='BLR']/following-sibling::DIV"));
        IWebElement TxtToCity => driver.FindElement(By.XPath("//DIV[@class='flight-search-source-code'][text()='Fly to']/following-sibling::DIV"));
        //IWebElement TxtSelectCity => driver.FindElement(By.XPath("//*[@id='basic - url']"));

        IWebElement TxtSelectCity => driver.FindElement(By.XPath("//DIV[@class='flight-search-source-code'][text()='BLR']"));

        public void EnterDetailsAndSearchFlights()
        {

            //TxtFromCity.Click();
            //TxtSelectCity.SendKeys("Mumbai");
            //String TxtFromCityName = "Mumbai, India";
            //driver.FindElement(By.XPath("//p[contains(text(),'" + TxtFromCityName + "')]")).Click();

            //TxtFromCity.SendKeys(Keys.Enter);
            //TxtToCity.SendKeys("Bengaluru");

            //TxtToCity.Click();
            TxtToCity.SendKeys("Delhi");
            //TxtSelectCity.SendKeys("Delhi");
            String TxtToCityName = "Delhi, India";
            driver.FindElement(By.XPath("//p[contains(text(),'" + TxtToCityName + "')]")).Click();
            Thread.Sleep(1000);
            BtnFlights.Click();
        }

        IWebElement BtnLoginSignUp => driver.FindElement(By.XPath("//p[contains(text(),'Login')]"));
        IWebElement TxtMobileNum => driver.FindElement(By.XPath("//input[@id='mobile-input-sso']"));
        IWebElement ElePopupHeader => driver.FindElement(By.XPath("//span[contains(text(),'Please enter the confirmation code')]"));
        IWebElement EleResendCodeLink => driver.FindElement(By.XPath("//span[contains(text(),'Resend Code')]"));
        IWebElement BtnContinue => driver.FindElement(By.XPath("//button[contains(text(),'Continue')]"));
        public void ClickOnLoginBtn()
        {
            BtnLoginSignUp.Click();
            Thread.Sleep(3000);
        }

        public void EnterMobileNum(String IntMobileNum)
        {
            TxtMobileNum.SendKeys(IntMobileNum);
            BtnContinue.Click();
        }


        public void ValidateLoginDialog()
        {
            bool BlnCheckPopupHeader = ElePopupHeader.Displayed;
            bool BlnCheckResendCodeLink = EleResendCodeLink.Displayed;
            bool BlnCheckContinue = BtnContinue.Displayed;
            if ((BlnCheckPopupHeader == true) & (BlnCheckResendCodeLink == true) & (BlnCheckContinue == true))
            {
                Console.WriteLine("Login Page Section is displayed with Header , Resend Code link and Continue button");
            }
        }



        //public void ValidateLoginError()
        //{
        //    Thread.Sleep(1000);
        //    bool check = eleLoginErrorMsg.Displayed;
        //    if (check == true)
        //    {
        //        Console.WriteLine("Login Error is Displayed as :{0}", eleLoginErrorMsg.Text);
        //    }
        //}
        public void ClickonFlights()
        {
            BtnFlights.Click();
            //IsPromoPanelDisplayed();
        }

        //public void IsPromoPanelDisplayed()
        //{
        //    if (notification_panel.Displayed)
        //    {
        //        deny_promos.Click();
        //    }
        //}
    }
}
