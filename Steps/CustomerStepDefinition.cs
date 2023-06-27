using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTestAutomationWebsite.Steps
{
    [Binding]
    public sealed class CustomerStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        private readonly string loginUrl = "https://itera-qa.azurewebsites.net/";

        public CustomerStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on the dashboard page")]
        public void GivenIAmOnTheDashboardPage()
        {
            Console.WriteLine("ScenarioTitle is: " + _scenarioContext.ScenarioInfo.Title);

            var chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeOptions);

            driver.Navigate().GoToUrl(loginUrl);
            driver.Manage().Window.Maximize();

            IWebElement loginLink = driver.FindElement(By.XPath("//a[normalize-space()='Login']"));
            loginLink.Click();

            var adminUserName = "admin";
            var adminPassword = "admin";

            IWebElement userName = driver.FindElement(By.XPath("//input[@id='Username']"));
            IWebElement passWord = driver.FindElement(By.XPath("//input[@id='Password']"));

            userName.SendKeys(adminUserName);
            passWord.SendKeys(adminPassword);

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@name='login']"));
            loginButton.Click();

            IWebElement dashboardText = driver.FindElement(By.XPath("//h1[normalize-space()='Dashboard']"));
            Assert.IsTrue(dashboardText.Displayed);
        }

        [Given(@"I click on the create new button")]
        public void GivenIClickOnTheCreateNewButton()
        {
            IWebElement createNewCustomer = driver.FindElement(By.XPath("//a[normalize-space()='Create New']"));
            createNewCustomer.Click();
        }

        [When(@"I fill the customer information")]
        public void WhenIFillTheCustomerInformation()
        {
            IWebElement nameField = driver.FindElement(By.XPath("//input[@id='Name']"));
            IWebElement companyField = driver.FindElement(By.XPath("//input[@id='Company']"));
            IWebElement addressField = driver.FindElement(By.XPath("//input[@id='Address']"));
            IWebElement cityField = driver.FindElement(By.XPath("//input[@id='City']"));
            IWebElement phoneField = driver.FindElement(By.XPath("//input[@id='Phone']"));
            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='Email']"));

            nameField.SendKeys("John");
            companyField.SendKeys("XXX Company");
            addressField.SendKeys("123, Baker Street, Perth, WA 6000");
            cityField.SendKeys(" Perth");
            phoneField.SendKeys("0123123321");
            emailField.SendKeys("johnpacker@gmail.com");
        }

        [When(@"I click on the create button")]
        public void WhenIClickOnTheCreateButton()
        {
            IWebElement createButton = driver.FindElement(By.XPath("//input[@value='Create']"));
            createButton.Click();
        }

        [Then(@"The customer should be created and navigated to ""([^""]*)"" page")]
        public void ThenTheCustomerShouldBeCreatedAndNavigatedToPage(string dashboard)
        {
            IWebElement dashboardText = driver.FindElement(By.XPath("//h1[normalize-space()='Dashboard']"));
            Assert.AreEqual(dashboard, dashboardText.Text);
            //_scenarioContext.Pending();
            driver.Quit();
        }

    }
}
