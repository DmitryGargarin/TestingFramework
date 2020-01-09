using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class SchemePage
    {
        private IWebDriver browser;
        private string schemePageId = "bx_651765591_982";
        public SchemePage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.Id(schemePageId)).Click();
        }
    }
}
