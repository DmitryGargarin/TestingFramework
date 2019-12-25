using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingFrameWork.Models;

namespace TestingFrameWork.Pages
{
    class VipPage
    {
        private IWebDriver browser;
        private IWebElement inputField;
        private string vipPageID = "bx_651765591_971";
        private string serveButtonXPath = "/html/body/div[2]/section/div/div/div/div/div/div";
        private string sendInfoButton = "form__btn";
        private string inputFieldName = "passenger-name-dep[1]";

        public VipPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.Id(vipPageID)).Click();
            inputField = browser.FindElement(By.Name(inputFieldName));
        }

        public void ServeButtonClick()
        {
            browser.FindElement(By.XPath(serveButtonXPath)).Click();
        }

        public void InsertTextInNameField(string text)
        {
            inputField.SendKeys(text);
        }

        public void SendInfoButtonClick()
        {
            browser.FindElement(By.ClassName(sendInfoButton)).Click();
        }

    }
}
