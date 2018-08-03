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
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;

namespace taqc2018
{
    [TestFixture]
    class Browsers
    {

        //[Test]
        public void Firefox1()
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Firefox2()
        {
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            //IWebDriver driver = new FirefoxDriver(profile); // Deprecated
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Firefox3()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.AcceptUntrustedCertificates = true;
            //profiles.AssumeUntrustedCertificateIssuer = true;
            //
            //profile.SetPreference("app.update.enabled", false);
            //profile.SetPreference("app.update.auto", false);
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Firefox4()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.AddExtension("D:\\selenium_ide.xpi");
            //profile.SetPreference("extensions.firebug.currentVersion", "2.0.19");
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //
            driver.Quit();
        }

        //[Test]
        public void Firefox5()
        {
            FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = "calc.exe";
            // Start application with a debugging console. Windows only.
            options.AddArgument("-console");
            // Runs Firefox in headless mode. Available in Firefox 56+
            options.AddArgument("-headless");
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotGoogle0.png", ScreenshotImageFormat.Png);
            //
            driver.Quit();
        }

        //[Test]
        public void IE1()
        {
            IWebDriver driver = new InternetExplorerDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void IE2()
        {
            InternetExplorerOptions options = new InternetExplorerOptions()
            {
                //InitialBrowserUrl = baseURL,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false
            };
            IWebDriver driver = new InternetExplorerDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome1()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized");
            //options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            //options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            string homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            Console.WriteLine("homePath = " + homePath);
            string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data";
            //options.AddArguments("--user-data-dir=" + userProfile);
            //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
            //IWebDriver driver = new ChromeDriver(options);
            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome2()
        {
            
            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.skype.com/en/");
            //
            IWebElement blogsElement = driver.FindElement(By.PartialLinkText("Blogs"));
            string blogsText = blogsElement.Text;
            Console.WriteLine("blogsText=" + blogsText + "=end");
            Thread.Sleep(2000);
            //
            Actions action = new Actions(driver);
            action.ClickAndHold().MoveToElement(blogsElement).Build().Perform();
            //action.MoveToElement(blogsElement).Build().Perform();
            Thread.Sleep(4000);
            //
            string toolTipText = driver.FindElement(By.CssSelector("a[href='https://blogs.skype.com']")).Text;
            Console.WriteLine("blogsElement=" + toolTipText + "=end");
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
