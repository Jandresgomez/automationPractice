using automationChallenges.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationChallenges.TestScripts
{
    [TestClass]
    public class ContactUs
    {
        IWebDriver driver;
        HomePage homePage;
        ContactUsPage contactUsPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver("Resources");
            homePage = new HomePage(driver);
            contactUsPage = new ContactUsPage(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
            homePage.GoToPage();
            homePage.ClickOnContackLink();
            contactUsPage.SelectContactValue();
            contactUsPage.FillContactForm("hola@mailinator.com", "1012252", "this is a test for automation");

            string success = contactUsPage.GetConfirmationText();
            Assert.AreEqual("Your message has been successfully sent to our team.", success);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
