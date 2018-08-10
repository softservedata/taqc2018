﻿using System;
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
    public class RepeatLoginPage : LoginPage
    {
        public IWebElement InvalidLoginLabel { get; private set; }

        public RepeatLoginPage(IWebDriver driver) : base(driver)
        {
            InvalidLoginLabel = driver.FindElement(By.XPath("//div[contains(@style,'red')]"));
        }

        // PageObject Atomic

        // InvalidLoginLabel
        public string GetInvalidLoginLabelText()
        {
            return InvalidLoginLabel.Text;
        }

        public void ClickInvalidLoginLabel()
        {
            InvalidLoginLabel.Click();
        }

        // Business Logic
    }
}