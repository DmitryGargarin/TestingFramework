using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class MainPage
    {
        private IWebDriver browser;

        public MainPage(IWebDriver driver)
        {
            browser = driver;
        }
        public void MoveToChangeAppearanceButton()
        {
            var element = browser.FindElement(By.ClassName("hdr-link--glasses"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }
        public void MenuButtonClick()
        {
            browser.FindElement(By.ClassName("hdr-link--nav")).Click();
        }
        public void RulesButtonClick()
        {
            browser.FindElement(By.XPath("//*[@Text='Правила']")).Click();
        }
        public void ChangeAppearanceButtonClick()
        {
            browser.FindElement(By.ClassName("hdr-link--glasses")).Click();
        }
        public void ChangeFontSize()
        {
            browser.FindElement(By.XPath("//*[@data-control='theme-font-lg']")).Click();
        }
        public void ChangeThemeColor()
        {
            browser.FindElement(By.XPath("//*[@data-control='theme-color-blind']")).Click();
        }
        public SearchPage SearchButtonClick()
        {
            return new SearchPage(browser);
        }

        public VipPage VipPageButtonClick()
        {
            return new VipPage(browser);
        }
        public PartnersPage PartnersPageButtonClick()
        {
            return new PartnersPage(browser);
        }
        public ArrivalPage ArrivalPageButtonClick()
        {
            return new ArrivalPage(browser);
        }
        public BuyTicketPage BuyTicketPageButtonClick()
        {
            return new BuyTicketPage(browser);
        }
        public BusinessHallPage BusinessHallPageButtonClick()
        {
            return new BusinessHallPage(browser);
        }
    }
}
