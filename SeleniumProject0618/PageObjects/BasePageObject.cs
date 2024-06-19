using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumProject0618.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected int DefaultWaitInSeconds=10;

        public BasePageObject(IWebDriver driver, int timeoutInSeconds = 10)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        protected IWebElement FindElement(By by)
        {
            return Wait.Until(driver => driver.FindElement(by));
        }

        protected IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Wait.Until(driver => driver.FindElements(by));
        }

        protected IWebElement WaitForElementToBeClickable(By by)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        protected IWebElement WaitForElementToBeVisible(By by)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        protected void ClickElement(By by)
        {
            var element = FindElement(by);
            element.Click();
        }

        protected void SendKeys(By by, string text)
        {
            var element = FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetPageTitle()
        {
            return Driver.Title;
        }

        protected string GetCurrentURL()
        {
            return Driver.Title;
        }

        protected string GetElementText(By by)
        {
            var element = FindElement(by);
            return element.Text;
        }

        protected void SwitchToFrame(By by)
        {
            var frame = FindElement(by);
            Driver.SwitchTo().Frame(frame);
        }

        ///empty the value of input field
        protected string WaitForInputFieldClearEmpty(By by)
        {
            //Wait for the result to be empty
            return WaitUntil(
                () => FindElement(by).GetAttribute("value"),
                result => result == string.Empty);
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T: class
        {
            DefaultWait<IWebDriver> fluentwait=new DefaultWait<IWebDriver>(Driver);
            fluentwait.Timeout=TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval=TimeSpan.FromMilliseconds(300);
            fluentwait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            
            return fluentwait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}
