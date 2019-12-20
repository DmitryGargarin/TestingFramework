using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class HotelPage
    {
        private IWebDriver browser;

        public HotelPage(IWebDriver driver)
        {
            browser = driver;
            MoveToHotelButton();
            browser.FindElement(By.Id("bx_651765591_985")).Click();
        }
        public void MoveToHotelButton()
        {
            var element = browser.FindElement(By.Id("bx_651765591_985"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }

        public void ChooseHotel()
        {
            browser.FindElement(By.XPath("//*[@target='_blank']")).Click();
        }
    }
}
