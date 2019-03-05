using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace automationChallenges
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
            string email = $"myemail@server.com";
            string pswd = "thisIsMyPassword";

            //Enter Homepage
            driver.Url = "http://automationpractice.com/index.php";

            //Enter Sign-in page
            driver.FindElement(By.ClassName("login")).Click();

            //Input email and password
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(pswd);
            driver.FindElement(By.Id("SubmitLogin")).Click();

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
