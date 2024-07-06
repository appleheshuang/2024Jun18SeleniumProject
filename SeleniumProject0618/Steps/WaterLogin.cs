using SeleniumProject0618.Drivers;
using SeleniumProject0618.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using OpenQA.Selenium;

namespace SeleniumProject0618.Steps
{
    [Binding]
    public sealed class WaterLogin
    {
        //Page Object for Calculator
        private readonly WaterLoginPage _WaterLoginPage;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public WaterLogin(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _WaterLoginPage = new WaterLoginPage(browserDriver.Webdriver, specFlowOutputHelper);
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given("watercare login")]
        public void WaterCareLogin()
        {
            //delegate to Page Object
            _WaterLoginPage.Login();
        }

    }
}