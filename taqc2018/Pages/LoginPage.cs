using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace taqc2018.Pages
{
    public class LoginPage : ATopComponent
    {
        public IWebElement LoginLabel { get; private set; }
        public IWebElement LoginInput { get; private set; }
        public IWebElement PasswordLabel { get; private set; }
        public IWebElement PasswordInput { get; private set; }
        public IWebElement SigninButton { get; private set; }
        public IWebElement LogoPicture { get; private set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            // TODO
            LoginLabel = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            LoginInput = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            PasswordLabel = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            PasswordInput = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            SigninButton = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            LogoPicture = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
        }

        // PageObject Atomic

        // LoginLabel
        // LoginInput
        // PasswordLabel
        // PasswordInput
        // SigninButton
        // LogoPicture

        // Business Logic
    }
}
