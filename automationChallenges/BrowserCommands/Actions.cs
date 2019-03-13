using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace automationChallenges.BrowserCommands
{
    public class Actions
    {

        public static void ClickOn(IWebDriver driver, IWebElement webElement)
        {
            try
            {
                webElement.Click();
                //Wait for site to load
                Thread.Sleep(5000);
            }
            catch(Exception err)
            {
                Console.Write(err.Message);
            }
        }

        public static void SelectByValue(IWebDriver driver, IWebElement webElement, string value)
        {
            try
            {
                SelectElement selectElement = new SelectElement(webElement);
                selectElement.SelectByValue(value);
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }

        public static void TypeKeysOnField(IWebDriver driver, IWebElement webElement, string keys)
        {
            try
            {
                webElement.SendKeys(keys);
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }

        public static string GetText(IWebDriver driver, IWebElement webElement)
        {
            try
            {
                string txt = webElement.Text;
                return txt;
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }

            return null;
        }
    }
}
