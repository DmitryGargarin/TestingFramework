﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestingFrameWork.Driver
{
    class DriverSingleton
    {
        private static IWebDriver driver;
        private DriverSingleton() { }
        public static IWebDriver SetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;

                    default:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void PrepareDriverToWork(IWebDriver browser)
        {
            browser.Navigate().GoToUrl("http://gsv.aero");
            browser.FindElement(By.ClassName("js-cookies-message__close")).Click();
        }
        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}