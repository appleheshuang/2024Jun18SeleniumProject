using SeleniumProject0618.Drivers;
using SeleniumProject0618.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using OpenQA.Selenium;

namespace SeleniumProject0618.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Page Object for Calculator
        private readonly CalculatorPageObject _calculatorPageObject;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public CalculatorStepDefinitions(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _calculatorPageObject = new CalculatorPageObject(browserDriver.Webdriver, specFlowOutputHelper);
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPageObject.EnterFirstNumber(number.ToString());
            _specFlowOutputHelper.WriteLine("Given first Number "+ number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPageObject.EnterSecondNumber(number.ToString());
            _specFlowOutputHelper.WriteLine("Given Second Number " + number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //delegate to Page Object
            _calculatorPageObject.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            //delegate to Page Object
            var actualResult = _calculatorPageObject.WaitForNonEmptyResult();

            actualResult.Should().Be(expectedResult.ToString());
        }
    }
}