using SeleniumUi.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumUi.Pages
{
    class AutoPracticePage
    {
        private readonly IWebDriver driver;
        private readonly CommonLibraries methods;

        public AutoPracticePage(IWebDriver driver)
        {
            this.driver = driver;
            methods = new CommonLibraries(driver);
        }


        IWebElement btnSignIn => driver.FindElement(By.XPath("//a[@class='login']"));


        public void ClickonSignInButton()
        {
            btnSignIn.Click();

        }

        public void RegisterNewUser()
        {
            Thread.Sleep(4000);
            //InputDataFile.RandomMail = CommonMethods.GetRandomEmail();
            driver.FindElement(By.Id("email_create")).SendKeys("auto.tester@gmail.com");
            //LogFile.LogInformation("entered valid email");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@id='SubmitCreate']")).Click();
            //LogFile.LogInformation("Clicked on creat account");
            Thread.Sleep(3000);
            // validating the registration page
            string Actual = driver.FindElement(By.XPath("//h1[text()='Create an account']")).Text;
            string Expected = "CREATE AN ACCOUNT";
            Assert.AreEqual(Expected, Actual);
            //LogFile.LogInformation("Registration Page is validated");

            //// creating a account
            driver.FindElement(By.Id("id_gender1")).Click();
            //LogFile.LogInformation("Clicked on title radio button");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("customer_firstname")).SendKeys("auto");
            //LogFile.LogInformation("First Name is entered");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("customer_lastname")).SendKeys("kumar");
            //LogFile.LogInformation("Last Name is entered");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("passwd")).SendKeys("kumar@2020");
            //LogFile.LogInformation("Password is entered");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("address1")).SendKeys("kumar");
            //LogFile.LogInformation("Address is entered");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("city")).SendKeys("Bangalore");
            //LogFile.LogInformation("City is entered");
            Thread.Sleep(3000);

            IWebElement stateListBox = driver.FindElement(By.Id("id_state"));

            SelectElement s = new SelectElement(stateListBox);
            Thread.Sleep(2000);
            s.SelectByText("Alabama");
            //LogFile.LogInformation("State is selected");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("postcode")).SendKeys("73301");
            //LogFile.LogInformation("Post code is entered");
            Thread.Sleep(3000);
            IWebElement countryListBox = driver.FindElement(By.Id("id_country"));

            SelectElement s1 = new SelectElement(countryListBox);
            Thread.Sleep(2000);
            s1.SelectByText("United States");
            //LogFile.LogInformation("Country is selected");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("phone_mobile")).SendKeys("8529631472");
            //LogFile.LogInformation("Mobile number is entered");
            Thread.Sleep(3000);
            // entering alias address
            IWebElement alias = driver.FindElement(By.Id("alias"));
            alias.Clear();
            Thread.Sleep(3000);
            alias.SendKeys("New York");
            //LogFile.LogErrorInformation("Alias address is entered");
            //driver.FindElement(By.Id("submitAccount")).Click();
            //LogFile.LogInformation("Clicked on register button");


        }




    }
}
