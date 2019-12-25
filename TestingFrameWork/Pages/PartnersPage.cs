using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class PartnersPage
    {
        private IWebDriver browser;
        private string schemePageID = "bx_651765591_982";
        private string partnersPage = "hdr-link--b";
        public PartnersPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.ClassName(partnersPage)).Click();
        }

        public void MoveToAboutPageButton()
        {
            var element = browser.FindElement(By.ClassName("card-content"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public void MoveToSchemeButton()
        {
            var element = browser.FindElement(By.ClassName(schemePageID));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public AboutPage AboutPageButtonClick()
        {
            return new AboutPage(browser);
        }
        public BusinessHallPage SchemePageButtonClick()
        {
            return new BusinessHallPage(browser);
        }
    }
}
