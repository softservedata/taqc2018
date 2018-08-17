using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace taqc2018.Tools.Find
{
    public class SearchExplicit : ASearch, ISearch
    {
        private WebDriverWait wait;

        public SearchExplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(0);
            wait = new WebDriverWait(Application.Get().Browser.Driver,
                TimeSpan.FromSeconds(Application.Get().ApplicationSource.ExplicitTimeOut));
            // TODO ImplicitLoadTimeOut, ImplicitScriptTimeOut
        }

        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            // TODO
            return (driver) =>
            {
                try
                {
                    //Console.WriteLine("element == null || !element.Enabled || !element.Displayed " + (element == null || !element.Enabled || !element.Displayed));
                    // Calling any method forces a staleness check
                    return element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public override bool StalenessOfWebElement(IWebElement IWebElement)
        {
            return wait.Until(StalenessOf(IWebElement));
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    //Console.WriteLine("InvisibilityOfElementLocated ...");
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            return wait.Until(InvisibilityOfElementLocated(by));
        }

        public override IWebElement GetWebElement(By by)
        {
            return wait.Until(driver => driver.FindElement(by));
        }

        public override ICollection<IWebElement> GetWebElements(By by)
        {
            // TODO +++
            return Application.Get().Browser.Driver.FindElements(by);
        }

    }
}
