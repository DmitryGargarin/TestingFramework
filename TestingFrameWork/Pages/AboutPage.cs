﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class AboutPage
    {
        private IWebDriver browser;
        private string aboutPageID = "bx_651765591_3505";

        public AboutPage(IWebDriver driver)
        {
            browser = driver;
            MoveToAboutPageButton();
            browser.FindElement(By.Id(aboutPageID)).Click();
        }
        public void MoveToAboutPageButton()
        {
            var element = browser.FindElement(By.ClassName("card-content"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
