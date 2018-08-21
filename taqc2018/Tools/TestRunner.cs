using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using taqc2018.Pages;
using taqc2018.Data.Users;
using taqc2018.Tools;
using taqc2018.Data.Application;
using NUnit.Framework.Interfaces;

namespace taqc2018.Tools
{
    [TestFixture]
    public abstract class TestRunner
    {
        protected readonly double DOUBLE_PRECISE = 0.01;
        //
        //protected bool isTestSuccess = false;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //Application.Get(ApplicationSourceRepository.ChromeTemporaryHeroku());
            Application.Get(); // Default
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            //Application.Get().LoadLoginPage();
            //isTestSuccess = false;
        }

        [TearDown]
        public void TearDown()
        {
            //if (!isTestSuccess)
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Application.Get().SaveCurrentState();
            }
            // Logout
            Application.Get().LogoutAction();
        }

        protected LoginPage StartApplication()
        {
            return Application.Get().LoadLoginPage();
        }
    }
}
