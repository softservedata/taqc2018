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
using taqc2018.UIMapping;
using OpenQA.Selenium.Support.PageObjects;
using taqc2018.Data.Users;
//#pragma warning disable

namespace taqc2018.Pages
{
    public class LoginPage : ATopComponent
    {
        public const string IMAGE_NAME = "ukraine_logo2.gif";
        //
        //private const string LOGIN_LABEL_XPATH = "//label[contains(@for,'inputEmail')]";
    	//private const string LOGIN_INPUT_ID = "login";
	    //private const string PASSWORD_LABEL_XPATH = "//label[contains(@for,'inputPassword')]";
	    //private const string PASSWORD_INPUT_ID = "password";
	    //private const string SIGNIN_BUTTON_CSSSELECTOR = "button.btn.btn-primary";
	    //private const string LOGO_PICTURE_CSSSELECTOR = "img.login_logo.col-md-8.col-xs-12";
        //
        public IWebElement LoginLabel //{ get; private set; }
            //{ get { return driver.FindElement(By.XPath("//label[contains(@for,'inputEmail')]")); } }
            { get { return driver.FindElement(By.XPath(LoginPageUIMap.LOGIN_LABEL_XPATH)); } }
        //[FindsBy(How = How.Id, Using = "login")]
        public IWebElement LoginInput //{ get; private set; }
            //{ get { return driver.FindElement(By.Id("login")); } }
            { get { return driver.FindElement(By.Id(LoginPageUIMap.LOGIN_INPUT_ID)); } }
        public IWebElement PasswordLabel //{ get; private set; }
            //{ get { return driver.FindElement(By.XPath("//label[contains(@for,'inputPassword')]")); } }
            { get { return driver.FindElement(By.XPath(LoginPageUIMap.PASSWORD_LABEL_XPATH)); } }
        //[CacheLookup]
        //[FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInput //{ get; private set; }
            //{ get { return driver.FindElement(By.Id("password")); } }
            { get { return driver.FindElement(By.Id(LoginPageUIMap.PASSWORD_INPUT_ID)); } }
        //[FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary")]
        public IWebElement SigninButton //{ get; private set; }
            //{ get { return driver.FindElement(By.CssSelector("button.btn.btn-primary")); } }
            { get { return driver.FindElement(By.CssSelector(LoginPageUIMap.SIGNIN_BUTTON_CSSSELECTOR)); } }
        public IWebElement LogoPicture //{ get; private set; }
            //{ get { return driver.FindElement(By.CssSelector("img.login_logo.col-md-8.col-xs-12")); } }
            { get { return driver.FindElement(By.CssSelector(LoginPageUIMap.LOGO_PICTURE_CSSSELECTOR)); } }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            // PageFactory
            //PageFactory.InitElements(driver, this);
            //
            // Classic Page Object
            //InitWebElements();
            VerifyWebElements();
        }

        //private void InitWebElements()
        //{
        //    LoginLabel = driver.FindElement(By.XPath("//label[contains(@for,'inputEmail')]"));
        //    LoginInput = driver.FindElement(By.Id("login"));
        //    PasswordLabel = driver.FindElement(By.XPath("//label[contains(@for,'inputPassword')]"));
        //    PasswordInput = driver.FindElement(By.Id("password"));
        //    SigninButton = driver.FindElement(By.CssSelector("button.btn.btn-primary"));
        //    LogoPicture = driver.FindElement(By.CssSelector("img.login_logo.col-md-8.col-xs-12"));
        //}

        private void VerifyWebElements()
        {
            IWebElement temp = LoginLabel;
            temp = LoginInput;
            temp = PasswordLabel;
            temp = PasswordInput;
            temp = SigninButton;
            temp = LogoPicture;
        }

        // PageObject Atomic

        // LoginLabel
        public string GetLoginLabelText()
        {
            return LoginLabel.Text;
        }

        public void ClickLoginLabel()
        {
            LoginLabel.Click();
        }

        // LoginInput
        public string GetLoginInputText()
        {
            return LoginInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void SetLoginInput(string text)
        {
            LoginInput.SendKeys(text);
        }

        public void ClearLoginInput()
        {
            LoginInput.Clear();
        }

        public void ClickLoginInput()
        {
            LoginInput.Click();
        }

        // Functional
        //public void SetLoginInputClear(string text)
        public LoginPage SetLoginInputClear(string text)
        {
            ClickLoginInput();
            ClearLoginInput();
            SetLoginInput(text);
            return this;
        }

        // PasswordLabel
        public string GetPasswordLabelText()
        {
            return PasswordLabel.Text;
        }

        public void ClickPasswordLabel()
        {
            PasswordLabel.Click();
        }

        // PasswordInput
        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void SetPasswordInput(string text)
        {
            PasswordInput.SendKeys(text);
        }

        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        public void ClickPasswordInput()
        {
            PasswordInput.Click();
        }

        // Functional
        //public void SetPasswordInputClear(string text)
        public LoginPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        // SigninButton
        public string GetSigninButtonText()
        {
            return SigninButton.Text;
        }

        public void ClickSigninButton()
        {
            SigninButton.Click();
        }

        // LogoPicture
        public string GetLogoPictureSrcAttributeText()
        {
            return LogoPicture.GetAttribute(SRC_ATTRIBUTE);
        }

        public void ClickLogoPicture()
        {
            LogoPicture.Click();
        }

        // Business Logic
        //public LoginPage changeLanguage(ChangeLanguageFields language)
        public LoginPage ChangeLanguage(string language) // TODO
        {
            SetChangeLanguage(language);
            return new LoginPage(driver);
        }

        private void SetLoginData(IUser user)
        //private void SetLoginData(string login, string password)
        {
            SetLoginInputClear(user.GetLogin());
            //SetLoginInputClear(login);
            SetPasswordInputClear(user.GetPassword());
            //SetPasswordInputClear(password);
            ClickSigninButton();
        }

        public RepeatLoginPage unsuccessfulLogin(IUser invalidUser)
        //public RepeatLoginPage unsuccessfulLogin(string invalidLogin, string invalidPassword)
        {
            SetLoginData(invalidUser);
            //SetLoginData(invalidLogin, invalidPassword);
            return new RepeatLoginPage(driver);
        }

        public RegistratorHomePage successRegistratorLogin(IUser registrator)
        //public RegistratorHomePage successRegistratorLogin(string registratorLogin, string registratorPassword)
        {
            SetLoginData(registrator);
            //SetLoginData(registratorLogin, registratorPassword);
            return new RegistratorHomePage(driver);
        }

    }
}
