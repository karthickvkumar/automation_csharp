using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.DevTools;
using System.Threading;

namespace Automation
{
    [TestClass]
    public class AppSession
    {
        protected static IWebDriver webDriver;
        public static void Setup(TestContext context)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver();

            if (!object.ReferenceEquals(null, context.Properties["siteURL"]))
            {
                webDriver.Url = context.Properties["siteURL"].ToString();
            }
            else
            {
                webDriver.Url = "https://www.npmjs.com/";
            }
                
            webDriver.Manage().Window.Maximize();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            webDriver.Quit();
        }

        [TestMethod]
        public void LoginToGmail_WithValidData_ShouldPass()
        {
            Thread.Sleep(4000);
            var signinButton = webDriver.FindElement(By.Id("signin"));
            signinButton.Click();

            Thread.Sleep(2000);

            var emailInput = webDriver.FindElement(By.Id("login_username"));
            emailInput.Clear();
            emailInput.SendKeys("karthick_fps");

            var passwordInput = webDriver.FindElement(By.Id("login_password"));
            passwordInput.Clear();
            passwordInput.SendKeys("8056202457VKK@k");

            var loginButton = webDriver.FindElement(By.XPath("//*[@id=\"login\"]/button"));
            loginButton.Click();

            Thread.Sleep(5000);
        }
    }
}
