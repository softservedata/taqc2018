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

namespace taqc2018
{
    [TestFixture]
    public class SmokeTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ValidUsers =
        {
            //new object[] { UserRepository.Get().Registered() },
            new object[] { UserRepository.Get().Registered() }
        };

        // DataProvider
        private static readonly object[] ExternalValidUsers =
            //ListUtils.ToMultiArray(UserRepository.Get().FromCsv());
            ListUtils.ToMultiArray(UserRepository.Get().FromExcel());

        //[Test, TestCaseSource(nameof(ValidUsers))]
        [Test, TestCaseSource("ValidUsers")]
        //[Test, TestCaseSource("ExternalValidUsers")]
        public void LoginTest9(IUser validRegistrator)
        {
            // Steps
            RegistratorHomePage registratorHomePage = StartApplication()
                .successRegistratorLogin(validRegistrator);
            //
            // Check
            Assert.AreEqual(validRegistrator.GetLogin(), registratorHomePage.GetLoginNameText(),
                "Assert Error. Invalid User Login.");
            //
            // Steps
            LoginPage loginPage = registratorHomePage.Logout();
            //
            // Check
            Assert.True(loginPage.GetLogoPictureSrcAttributeText()
                .Contains(LoginPage.IMAGE_NAME), "Assert Error. LoginPage not Found.");
            //
            isTestSuccess = true;
        }
    }
}
