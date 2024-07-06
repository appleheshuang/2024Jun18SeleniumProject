using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace SeleniumProject0618.PageObjects{
    public class WaterLoginPage:BasePageObject
    {
        private const string WatercareURl = "https://www.watercare.co.nz/";
        public IDictionary<String, Object> vars {get; private set;}

        public WaterLoginPage(IWebDriver webDriver, ISpecFlowOutputHelper specFlowOutputHelper):base(webDriver,specFlowOutputHelper)
         {

         }
        //Finding elements by ID
        private IWebElement MyAccount => FindElementwithFluentWait(By.Id("id attribute is not available for this element"));
        [Fact]
        public void Login()
        {
            // Driver.Navigate().GoToUrl(WatercareURl);
            // Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.watercare.co.nz/");
            Driver.Manage().Window.Maximize();
            // vars["WindowHandles"] = Driver.WindowHandles;
            Driver.FindElement(By.LinkText("MyAccount")).Click();
            vars["win5394"] = waitForWindow(2000);
            Driver.SwitchTo().Window(vars["win5394"].ToString());
            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("appleheshuang@gmail.com");
            Driver.FindElement(By.Id("password")).SendKeys("87654312aA$");
            Driver.FindElement(By.Id("next")).Click();
            Driver.FindElement(By.CssSelector(".pr-20")).Click();
            Driver.FindElement(By.CssSelector(".pr-\\[6\\.5em\\]")).SendKeys("77");
            Driver.FindElement(By.CssSelector(".right-px")).Click();

        }

        public string waitForWindow(int timeout) {
            try {
            Thread.Sleep(timeout);
            } catch(Exception e) {
            Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = ((IReadOnlyCollection<object>)Driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count) {
            return whNow.Except(whThen).First().ToString();
            } else {
            return whNow.First().ToString();
            }
        }


        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (Driver.Url != WatercareURl)
            {
                Driver.Url = WatercareURl;
            }
            //Otherwise reset the calculator by clicking the reset button

        }
    }
}