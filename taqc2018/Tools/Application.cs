﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taqc2018.Data.Application;
using taqc2018.Pages;

namespace taqc2018.Tools
{
    public class Application
    {
        private volatile static Application instance;
        private static object lockingObject = new object();
        //private static Logger log = LogManager.GetCurrentClassLogger();

        // TODO Change for parallel work
        public ApplicationSource ApplicationSource { get; private set; }
        //public FlexAssert FlexAssert { get; private set; }
        public BrowserWrapper Browser { get; private set; }
        //public ISearch Search { get; private set; }
        //public DBConnectionWrapper dbConnection { get; private set; }

        private Application(ApplicationSource applicationSource)
        {
            this.ApplicationSource = applicationSource;
        }

        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSource applicationSource)
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        if (applicationSource == null)
                        {
                            applicationSource = ApplicationSourceRepository.Default();
                        }
                        instance = new Application(applicationSource);
                        //
                        instance.InitBrowser(applicationSource);
                        instance.InitSearch(applicationSource);
                    }
                }
            }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                // TODO Change for parallel work
                instance.Browser.Quit();
                // Close DBConnection, etc.
                instance = null;
            }
        }

        private void InitBrowser(ApplicationSource applicationSource)
        {
            this.Browser = new BrowserWrapper(applicationSource);
        }

        private void InitSearch(ApplicationSource applicationSource)
        {
            //this.Search = new SearchElement(applicationSource);
        }

        public LoginPage LoadLoginPage()
        {
            //log.Debug("Start LoadLoginPage()");
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            return new LoginPage(Browser.Driver);
            //return new LoginPage();
        }

        //public LogoutPage LogoutAction()
        public LoginPage LogoutAction()
        //public void LogoutAction()
        {
            Browser.OpenUrl(ApplicationSource.LogoutUrl);
            return new LoginPage(Browser.Driver);
            //return new LogoutPage();
        }

        public void SaveCurrentState()
        {
            //log.Warn("Saved Current State");
            string prefix = Browser.SaveScreenshot();
            Browser.SaveSourceCode(prefix);
        }

    }

}
