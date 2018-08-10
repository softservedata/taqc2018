﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using taqc2018.Pages;

namespace taqc2018
{
    //[TestFixture]
    public class SeleniumSecond
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/login");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/logout");
        }

        //[Test]
        public void LoginTest1()
        {
            // Steps
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.AreEqual("work1",
                driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)")).Text);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            driver.FindElement(By.XPath("//a[contains(@href,'/logout')]")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.True(driver.FindElement(By.CssSelector("div.signin-container img"))
                .GetAttribute("src").Contains("ukraine_logo2.gif"));
        }

        //[Test]
        public void LoginTest2()
        {
            // Steps
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.AreEqual("work",
                driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)")).Text);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            driver.FindElement(By.XPath("//a[contains(@href,'/logout')]")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Check
            Assert.True(driver.FindElement(By.CssSelector("div.signin-container img"))
                .GetAttribute("src").Contains("ukraine_logo2.gif"));
        }

        //[Test]
        public void LoginTest3()
        {
            // Steps
            //
            //IWebElement login = driver.FindElement(By.Id("login"));
            //login.Click();
            //login.Clear();
            //login.SendKeys("Hello");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            // For Example, AJAX Refresh Element
            //driver.Navigate().Refresh();
            //
            //login.Click();
            //login.Clear();
            //login.SendKeys("work");
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("Hello");
            Thread.Sleep(1000);
            //
            // For Example, AJAX Refresh Element
            driver.Navigate().Refresh();
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            //driver.FindElement(By.Id("password")).Submit();
            Thread.Sleep(1000); // For Presentation ONLY
            //
        }

        //[Test]
        public void LoginTest4()
        {
            // Steps
            //driver.FindElement(By.Id("login")).Click();
            //driver.FindElement(By.Id("login")).Clear();
            //driver.FindElement(By.Id("login")).SendKeys("work");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.Id("password")).Click();
            //driver.FindElement(By.Id("password")).Clear();
            //driver.FindElement(By.Id("password")).SendKeys("qwerty");
            //Thread.Sleep(1000); // For Presentation ONLY
            //
            //driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            //
            //LoginPage loginPage = new LoginPage(driver);
            //loginPage.SetLoginInputClear("work");
            //loginPage.SetPasswordInputClear("qwerty");
            //loginPage.ClickSigninButton();
            //
            //new LoginPage(driver)
            //    .SetLoginInputClear("work")
            //    .SetPasswordInputClear("qwerty")
            //    .ClickSigninButton();
            //
            new LoginPage(driver)
                .successRegistratorLogin("work", "qwerty");
            //
            Thread.Sleep(4000); // For Presentation ONLY
            //
        }

        //[Test]
        public void LoginTest5()
        {
            // Steps
            RegistratorHomePage registratorHomePage = new LoginPage(driver)
                .successRegistratorLogin("work", "qwerty");
            //
            // Check
            Assert.AreEqual("work", registratorHomePage.GetLoginNameText());
            //
            // Steps
            LoginPage loginPage = registratorHomePage.Logout();
            //
            // Check
            //Assert.True(loginPage.GetLogoPictureSrcAttributeText()
            //    .Contains("ukraine_logo2.gif"));
            Assert.True(loginPage.GetLogoPictureSrcAttributeText()
                .Contains(LoginPage.IMAGE_NAME));
        }

        [Test]
        public void LoginTest6()
        {
            // Steps
            RepeatLoginPage repeatLoginPage = new LoginPage(driver)
                .unsuccessfulLogin("hahaha", "qwerty");
            //
            // Check
            Assert.True(repeatLoginPage.GetInvalidLoginLabelText().Length > 0);
        }

    }
}
