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
        private string hotelPageId = "bx_651765591_985";
        private string hotelXPath = "//*[@target='_blank']";
        public HotelPage(IWebDriver driver)
        {
            browser = driver;
            MoveToHotelButton();
            browser.FindElement(By.Id(hotelPageId)).Click();
        }
        public void MoveToHotelButton()
        {
            var element = browser.FindElement(By.XPath(hotelXPath));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }

        public void ChooseHotel()
        {
            browser.FindElement(By.XPath(hotelXPath)).Click();
        }
    }
}
