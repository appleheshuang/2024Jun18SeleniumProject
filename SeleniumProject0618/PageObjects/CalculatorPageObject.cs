using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumProject0618.PageObjects{
    public class CalculatorPageObject:BasePageObject
    {
        private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        public CalculatorPageObject(IWebDriver webDriver, ISpecFlowOutputHelper specFlowOutputHelper):base(webDriver,specFlowOutputHelper)
         {

         }
        //Finding elements by ID
        private IWebElement FirstNumberElement => FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => FindElement(By.Id("add-button"));
        private IWebElement ResultElement => FindElement(By.Id("result"));
        private IWebElement ResetButtonElement => FindElement(By.Id("reset-button"));


        public void EnterFirstNumber(string number)
            {
                //Clear text box
                FirstNumberElement.Clear();
                //Enter text
                FirstNumberElement.SendKeys(number);
            }

              public void EnterSecondNumber(string number)
            {
                 _specFlowOutputHelper.WriteLine("Find Element");
                //Clear text box
                SecondNumberElement.Clear();
                //Enter text
                SecondNumberElement.SendKeys(number);
            }

        public void ClickAdd()
        {
            //Click the add button
            AddButtonElement.Click();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (Driver.Url != CalculatorUrl)
            {
                Driver.Url = CalculatorUrl;
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                ResetButtonElement.Click();

                //Wait until the result is empty again
                WaitForEmptyResult();
            }
        }

        public string WaitForNonEmptyResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForEmptyResult()
        {
            //Wait for the result to be empty
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
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
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });

        }

    }
}