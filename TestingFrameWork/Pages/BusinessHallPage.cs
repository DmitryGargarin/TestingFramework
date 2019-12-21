using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class BusinessHallPage
    {
        private IWebDriver browser;

        public BusinessHallPage(IWebDriver driver)
        {
            browser = driver;
            MoveToBusinessHallButton();
            browser.FindElement(By.Id("bx_651765591_972")).Click();
        }

        public void MoveToBusinessHallButton()
        {
            var element = browser.FindElement(By.Id("bx_651765591_972"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }
    }
}
