using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTestAutomationWebsite
{
    [Binding]
    public sealed class LoginStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        private readonly string loginUrl = "https://itera-qa.azurewebsites.net/";

        public LoginStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I click on login url")]
        public void GivenIClickOnLoginUrl()
        {
            Console.WriteLine("ScenarioTitle is: " + _scenarioContext.ScenarioInfo.Title);
            var chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeOptions);

            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Window.Maximize();

            IWebElement loginLink = driver.FindElement(By.XPath("//a[normalize-space()='Login']"));
            loginLink.Click();
        }

        [When(@"I type user credentials")]
        public void WhenITypeUserCredentials()
        {
            var adminUserName = "admin";
            var adminPassword = "admin";

            IWebElement userName = driver.FindElement(By.XPath("//input[@id='Username']"));
            IWebElement passWord = driver.FindElement(By.XPath("//input[@id='Password']"));
          
            userName.SendKeys(adminUserName);
            passWord.SendKeys(adminPassword);
        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@name='login']"));
            loginButton.Click();
        }

        [Then(@"Dashboard page should be displayed")]
        public void ThenDashboardPageShouldBeDisplayed()
        {
            IWebElement dashboardText = driver.FindElement(By.XPath("//h1[normalize-space()='Dashboard']"));
            Assert.IsTrue(dashboardText.Displayed);
            driver.Quit();
        }

    }
}
