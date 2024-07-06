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
    public class WaterCareHooks
    {
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

    public WaterCareHooks(ISpecFlowOutputHelper outputHelper)
    {
        _specFlowOutputHelper = outputHelper;
    }
        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("WaterCare")]
        public void BeforeScenario(BrowserDriver browserDriver)
        {
            var WaterLoginPage = new WaterLoginPage(browserDriver.Webdriver, _specFlowOutputHelper);
            WaterLoginPage.EnsureCalculatorIsOpenAndReset();

            _specFlowOutputHelper.WriteLine("Before Scenario Log");
        }
    }
}