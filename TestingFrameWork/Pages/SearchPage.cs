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
        private string searchPage = "hdr-link--search";
        private string inputFieldClass = "search-input";
        private string searchButton = "search-btn";
        private string firstAnswerXPath = "//a[@class='search-result']";
        public SearchPage(IWebDriver driver)
        {
            browser = driver;
            browser.FindElement(By.ClassName(searchPage)).Click();
            inputField = browser.FindElement(By.ClassName(inputFieldClass));
        }
        public void MoveToSearchButton()
        {
            var element = browser.FindElement(By.ClassName(searchButton));
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
            browser.FindElement(By.XPath(firstAnswerXPath)).Click();
        }
        public void SearchButtonClick()
        {
            browser.FindElement(By.ClassName(searchButton)).Click();

        }
    }
}
