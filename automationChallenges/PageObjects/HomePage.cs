using System;
using automationChallenges.BrowserCommands;
using OpenQA.Selenium;

namespace automationChallenges.PageObjects
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebDriver driver;


        public IWebElement GetContactUsDiv()
        {
            return driver.FindElement(By.Id("contact-link"));
        }

        public void ClickOnContackLink()
        {
            Actions.ClickOn(driver, this.GetContactUsDiv());
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
