using SeleniumProject0618.Drivers;
using SeleniumProject0618.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SeleniumProject0618.Hooks
{
    /// <summary>
    /// Calculator related hooks
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

    public CalculatorHooks(ISpecFlowOutputHelper outputHelper)
    {
        _specFlowOutputHelper = outputHelper;
    }
        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("Calculator")]
        public void BeforeScenario(BrowserDriver browserDriver)
        {
            var calculatorPageObject = new CalculatorPageObject(browserDriver.Webdriver, _specFlowOutputHelper);
            calculatorPageObject.EnsureCalculatorIsOpenAndReset();

            _specFlowOutputHelper.WriteLine("Before Scenario Log");
        }
    }
}