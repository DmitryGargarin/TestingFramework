using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFrameWork.Pages
{
    class SearchPage
    {
        private IWebDriver browser;
        private IWebElement inputField;
        public SearchPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.ClassName("hdr-link--search")).Click();
            inputField = browser.FindElement(By.Name("q"));
        }
        public void MoveToSearchButton()
        {
            var element = browser.FindElement(By.ClassName("search-btn"));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }
        public void InsertTextInSearchField(string text)
        {
            inputField.SendKeys(text);
        }
        public void GetFirstAnswerAndGoToUrl()
        {
            browser.FindElement(By.XPath("//a[@class='search-result']")).Click();
        }
        public void SearchButtonClick()
        {
            browser.FindElement(By.ClassName("search-btn")).Click();

        }
    }
}
