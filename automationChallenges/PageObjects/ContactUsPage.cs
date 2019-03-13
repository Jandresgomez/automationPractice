using System;
using automationChallenges.BrowserCommands;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace automationChallenges.PageObjects
{
    public class ContactUsPage
    {
        private IWebDriver driver;

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Page Objects
        public IWebElement GetContactIdField()
        {
            return driver.FindElement(By.Id("id_contact"));
        }

        private IWebElement GetEmailField()
        {
            return driver.FindElement(By.Id("email"));
        }

        private IWebElement GetOrderIdField()
        {
            return driver.FindElement(By.Id("id_order"));
        }

        private IWebElement GetMessageField()
        {
            return driver.FindElement(By.Id("message"));
        }

        private IWebElement GetSubmitButton()
        {
            return driver.FindElement(By.Id("submitMessage"));
        }

        private IWebElement GetConfirmationParagraph()
        {
            return driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p"));
        }

        //Interactions
        public void SelectContactValue()
        {
            Actions.SelectByValue(driver, this.GetContactIdField(), "2");
        }

        public void FillContactForm(string email, string id, string message)
        {
            Actions.TypeKeysOnField(driver, this.GetEmailField(), email);
            Actions.TypeKeysOnField(driver, this.GetOrderIdField(), id);
            Actions.TypeKeysOnField(driver, this.GetMessageField(), message);
        }

        public void SubmitForm()
        {
            Actions.ClickOn(driver, this.GetSubmitButton());
        }

        public string GetConfirmationText()
        {
            return Actions.GetText(driver, this.GetConfirmationParagraph());
        }
    }
}
