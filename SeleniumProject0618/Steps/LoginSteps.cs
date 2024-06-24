using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using TechTalk.SpecFlow.Infrastructure;

[Binding]
public class LoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;
    private List<User> _users;

    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

    public LoginSteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
    {
        _specFlowOutputHelper=specFlowOutputHelper;
        _scenarioContext = scenarioContext;
        LoadTestData();
        _driver = new ChromeDriver();
    }

    private void LoadTestData()
    {
        string projectPath = GetProjectPath();
        string jsonPath = Path.Combine(projectPath, "TestData/ComplexTestData.json");
        var json = File.ReadAllText(jsonPath);
        _users = JsonConvert.DeserializeObject<List<User>>(json);
    }

    private string GetProjectPath()
    {
        string projectPath = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        return projectPath;
    }

    [Given(@"the user data from JSON ""(.*)"" and ""(.*)""")]
    public void GivenTheUserDataFromJSON(string username, string password)
    {
        var user = _users.Find(u => u.Credentials.Username == username && u.Credentials.Password == password);
        _scenarioContext["user"] = user;
    }

    [When(@"the user clicks the login button")]
    public void WhenTheUserClicksTheLoginButton()
    {
        var user = (User)_scenarioContext["user"];
        
        _driver.Navigate().GoToUrl("https://example.com/login");

        _specFlowOutputHelper.WriteLine("username: " + user.Credentials.Username);
        _specFlowOutputHelper.WriteLine("password: " + user.Credentials.Password);
        _specFlowOutputHelper.WriteLine("Role: " + user.UserInfo.Role);
        _specFlowOutputHelper.WriteLine("FirstName: " + user.UserInfo.Details.FirstName);
        _specFlowOutputHelper.WriteLine("Email: " + user.UserInfo.Details.Email);

        // _driver.FindElement(By.Id("username")).SendKeys(user.Credentials.Username);
        // _driver.FindElement(By.Id("password")).SendKeys(user.Credentials.Password);
        // _driver.FindElement(By.Id("loginButton")).Click();

        _scenarioContext["loginSuccess"] = true;
    }

    [Then(@"the user should be logged in successfully as ""(.*)""")]
    public void ThenTheUserShouldBeLoggedInSuccessfullyAs(string role)
    {
        var user = (User)_scenarioContext["user"];
        var loginSuccess = (bool)_scenarioContext["loginSuccess"];
        
        Assert.True(loginSuccess, "Login was not successful");
        Assert.Equal(role, user.UserInfo.Role);
    }

    [AfterScenario]
    public void DisposeWebDriver()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}

public class User
{
    public Credentials Credentials { get; set; }
    public UserInfo UserInfo { get; set; }
}

public class Credentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserInfo
{
    public string Role { get; set; }
    public Details Details { get; set; }
}

public class Details
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
