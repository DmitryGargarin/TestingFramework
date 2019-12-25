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
        private string changeAppearanceButton = "hdr-link--glasses";
        private string menuButton = "hdr-link--nav";
        private string rulesXPath = "//*[@Text='Правила']";
        private string changeFontSizeXPath = "//*[@data-control='theme-font-lg']";
        private string changeThemeColorXPath = "//*[@data-control='theme-color-blind']";
        public MainPage(IWebDriver driver)
        {
            browser = driver;
        }
        public void MoveToChangeAppearanceButton()
        {
            var element = browser.FindElement(By.ClassName(changeAppearanceButton));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }
        public void MenuButtonClick()
        {
            browser.FindElement(By.ClassName(menuButton)).Click();
        }
        public void RulesButtonClick()
        {
            browser.FindElement(By.XPath(rulesXPath)).Click();
        }
        public void ChangeAppearanceButtonClick()
        {
            browser.FindElement(By.ClassName(changeAppearanceButton)).Click();
        }
        public void ChangeFontSize()
        {
            browser.FindElement(By.XPath(changeFontSizeXPath)).Click();
        }
        public void ChangeThemeColor()
        {
            browser.FindElement(By.XPath(changeThemeColorXPath)).Click();
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
