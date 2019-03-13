using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace automationChallenges.TestScripts
{
    [TestClass]
    public class SignIn
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
            string email = "myemail1@server.com";
            string pswd = "thisIsMyPassword";

            //Enter Homepage
            driver.Url = "http://automationpractice.com/index.php";

            //Enter Sign-in page
            driver.FindElement(By.ClassName("login")).Click();

            //Wait for site to load
            Thread.Sleep(5000);

            //Input email and password
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(pswd);
            driver.FindElement(By.Id("SubmitLogin")).Click();

            //Wait for site to load
            Thread.Sleep(5000);

            //Verify Login
            string confirmation = driver.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", confirmation);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
