using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class VipPage
    {
        private IWebDriver browser;
        private IWebElement inputField;

        public VipPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.Id("bx_651765591_971")).Click();
            inputField = browser.FindElement(By.Name("passenger-name-dep[1]"));
        }

        public void ServeButtonClick()
        {
            browser.FindElement(By.XPath("/html/body/div[2]/section/div/div/div/div/div/div")).Click();
        }

        public void InsertTextInNameField(string text)
        {
            inputField.SendKeys(text);
        }



    }
}
