using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace automationChallenges.TestScripts
{
    [TestClass]
    public class RegisterAccount
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver("Resources");
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Data 
            int id = (new Random()).Next(1000);
            string email = $"myemail{id}@server.com";
            string pswd = "thisIsMyPassword";

            //Enter Homepage
            driver.Url = "http://automationpractice.com/index.php";

            //Enter Sign-in page
            driver.FindElement(By.ClassName("login")).Click();

            //Wait for site to load
            Thread.Sleep(5000);

            //Submit the email for account creation
            driver.FindElement(By.Id("email_create")).SendKeys(email);
            driver.FindElement(By.Id("SubmitCreate")).Click();

            //Wait for site to load
            Thread.Sleep(5000);

            FillForm(pswd);

            //Wait for site to load
            Thread.Sleep(5000);

            //Verify Account Creation
            string confirmation = driver.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", confirmation);

            //Logout
            driver.FindElement(By.ClassName("logout")).Click();
            string label = driver.FindElement(By.ClassName("page-heading")).Text;
            Assert.AreEqual("AUTHENTICATION", label);
        }

        public void FillForm(string pswd)
        {
            //Fill Personal Info
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Jorge");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Gomez");
            driver.FindElement(By.Id("passwd")).SendKeys(pswd);
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByValue("10");
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByValue("10");
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByValue("1990");

            //Fill Address Info
            driver.FindElement(By.Id("company")).SendKeys("BLTRX");
            driver.FindElement(By.Id("address1")).SendKeys("1056  Beeghley Street");
            driver.FindElement(By.Id("city")).SendKeys("Waco");
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByValue("43");
            driver.FindElement(By.Id("postcode")).SendKeys("76705");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("254-853-5333");
            driver.FindElement(By.Id("submitAccount")).Click();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
