using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taqc2018.Data.Application;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace taqc2018.Tools.Find
{
    public class SearchImplicit : ASearch, ISearch
    {
        public SearchImplicit()
        {
            ResetWaits();
        }

        public override void ResetWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            // TODO ImplicitLoadTimeOut, ImplicitScriptTimeOut
        }

        public override bool StalenessOfWebElement(IWebElement IWebElement)
        {
            //DateTime localDate = DateTime.Now;
            //GetTimestamp(DateTime.Now);
            // TODO +++ webElement == null || !webElement.Enabled;
            return true;
        }

        public override bool InvisibilityOfWebElementLocated(By by)
        {
            // TODO +++ webElement == null || !webElement.Enabled;
            return true;
        }

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }
    }
}
