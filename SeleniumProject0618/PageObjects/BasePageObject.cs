using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumProject0618.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected int DefaultWaitInSeconds=10;

        protected ISpecFlowOutputHelper _specFlowOutputHelper;


        public BasePageObject(IWebDriver driver, ISpecFlowOutputHelper specFlowOutputHelper, int timeoutInSeconds = 10)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            _specFlowOutputHelper=specFlowOutputHelper;
        }

        //  Explicit Wait
        protected IWebElement FindElement(By by)
        {
            _specFlowOutputHelper.WriteLine("Find Element");
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

        public void AcceptAlert()
        {
            var alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void SelectDropdownOption(By locator, string optionText)
        {
            var dropdown = new SelectElement(Driver.FindElement(locator));
            dropdown.SelectByText(optionText);
        }
        
        //fluent wait
        protected IWebElement FindElementwithFluentWait(By by)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
 
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(by));
            return searchResult;
        }
    }
}

