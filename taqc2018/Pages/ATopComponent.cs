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
using taqc2018.Tools;
using taqc2018.Tools.Find;

namespace taqc2018.Pages
{
    public abstract class ATopComponent
    {
        public const string SRC_ATTRIBUTE = "src";
        public const string VALUE_ATTRIBUTE = "value";
        //
        protected ISearch Search { get; private set; }
        //protected IWebDriver driver;
        //
        public IWebElement TitleLabel //{ get; private set; }
            //{ get { return driver.FindElement(By.XPath("//div[@id='header']/div/h3/..")); } }
            { get { return Search.XPath("//div[@id='header']/div/h3/.."); } }
        public SelectElement ChangeLanguage //{ get; private set; }
            //{ get { return new SelectElement(driver.FindElement(By.Id("changeLanguage"))); } }
            { get { return new SelectElement(Search.Id("changeLanguage")); } }

        //protected ATopComponent(IWebDriver driver)
        protected ATopComponent()
        {
            Search = Application.Get().Search;
            //this.driver = driver;
            //
            // Classic Page Object
            //TitleLabel = driver.FindElement(By.XPath("//div[@id='header']/div/h3/.."));
            //ChangeLanguage = new SelectElement(driver.FindElement(By.Id("changeLanguage")));
            //
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement temp = TitleLabel;
            SelectElement select = ChangeLanguage;
        }

        // PageObject Atomic

        // TitleLabel
        public string GetTitleLabelText()
        {
            return TitleLabel.Text;
        }

        public void ClickTitleLabel()
        {
            TitleLabel.Click();
        }

        // ChangeLanguage
        public IWebElement GetChangeLanguageWebElement()
        {
            return ChangeLanguage.AllSelectedOptions[0];
        }

        public string GetChangeLanguageText()
        {
            return GetChangeLanguageWebElement().Text;
        }

        // TODO
        public void SetChangeLanguage(string language)
        {
            ChangeLanguage.SelectByText(language);
        }

        // Business Logic
    }
}
