using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class ArrivalPage
    {
        private IWebDriver browser;

        public ArrivalPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.XPath("//a[@data-path='in']")).Click();
        }

        public HotelPage HotelPageButtonClick()
        {
            return new HotelPage(browser);
        }
    }
}
