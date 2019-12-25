using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingFrameWork.Models;

namespace TestingFrameWork.Pages
{
    class BuyTicketPage
    {
        private IWebDriver browser;

        private IWebElement destinationCity;
        private IWebElement departureCity;

        private IWebElement name;
        private IWebElement lastname;
        private IWebElement thirdname;
        private IWebElement birthdate;
        private IWebElement documentNumber;
        private IWebElement phone;
        private IWebElement mail;

        private FlightModel flight = new FlightModel("Санкт-Петербург", "Москва");
        private UserModel defaultUser = UserModel.DefaultUser();
        private UserModel noNumberUser = UserModel.UserWithoutNumber();
        private UserModel noCardUser = UserModel.UserWithoutCard();

        private string buyTicketPageID = "bx_651765591_978";
        private string nameID = "name_adult_1";
        private string surnameID = "surname_adult_1";
        private string middlenameID = "middlename_adult_1";
        private string birthdateID = "birthdate_adult_1";
        private string docID = "docnumber_adult_1";
        private string phoneID = "phone";
        private string mailID = "email";
        private string pickPlaneButton = "//div[@class='price']";
        public BuyTicketPage(IWebDriver driver)
        {
            browser = driver;
            MoveToBuyTicketButton();
            browser.FindElement(By.Id(buyTicketPageID)).Click();
        }
        public void MoveToBuyTicketButton()
        {
            var element = browser.FindElement(By.Id(buyTicketPageID));
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();

        }
        public void InputFlightInfo()
        {
            departureCity = browser.FindElement(By.Id("departure"));
            departureCity.SendKeys(flight.departureCity);
            destinationCity = browser.FindElement(By.Id("arrival"));
            destinationCity.SendKeys(flight.departureCity);
            browser.FindElement(By.ClassName("btn-search")).Click();
        }
        public void PickAirplane()
        {
            browser.FindElement(By.XPath(pickPlaneButton)).Click();
        }
        public void InputUserInfo(UserModel user)
        {
            name = browser.FindElement(By.Id(nameID)); name.SendKeys(user.name);
            lastname = browser.FindElement(By.Id(surnameID)); lastname.SendKeys(user.lastname);
            thirdname = browser.FindElement(By.Id(middlenameID)); thirdname.SendKeys(user.thirdname);
            birthdate = browser.FindElement(By.Id(birthdateID)); birthdate.SendKeys(user.birthday);
            documentNumber = browser.FindElement(By.Id(docID)); documentNumber.SendKeys(user.birthday);
            phone = browser.FindElement(By.Id(phoneID)); phone.SendKeys(user.phoneNumber);
            mail = browser.FindElement(By.Id(mailID)); mail.SendKeys(user.mail);
            browser.FindElement(By.ClassName("btn-payment")).Click();
        }
    }
}
