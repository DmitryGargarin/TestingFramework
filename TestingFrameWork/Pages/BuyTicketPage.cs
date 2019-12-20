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

        public BuyTicketPage(IWebDriver driver)
        {
            browser = driver;
            MoveToBuyTicketButton();
            browser.FindElement(By.Id("bx_651765591_978")).Click();
        }
        public void MoveToBuyTicketButton()
        {
            var element = browser.FindElement(By.Id("bx_651765591_985"));
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
            browser.FindElement(By.XPath("//div[@class='price']")).Click();
        }
        public void InputDefaultUserInfo()
        {
            name = browser.FindElement(By.Id("name_adult_1")); name.SendKeys(defaultUser.name);
            lastname = browser.FindElement(By.Id("surname_adult_1")); lastname.SendKeys(defaultUser.lastname);
            thirdname = browser.FindElement(By.Id("middlename_adult_1")); thirdname.SendKeys(defaultUser.thirdname);
            birthdate = browser.FindElement(By.Id("birthdate_adult_1")); birthdate.SendKeys(defaultUser.birthday);
            documentNumber = browser.FindElement(By.Id("docnumber_adult_1")); documentNumber.SendKeys(defaultUser.birthday);
            phone = browser.FindElement(By.Id("phone")); phone.SendKeys(defaultUser.phoneNumber);
            mail = browser.FindElement(By.Id("email")); mail.SendKeys(defaultUser.mail);
            browser.FindElement(By.ClassName("btn-payment")).Click();
        }
        public void InputNoNumberUserInfo()
        {
            name = browser.FindElement(By.Id("name_adult_1")); name.SendKeys(noNumberUser.name);
            lastname = browser.FindElement(By.Id("surname_adult_1")); lastname.SendKeys(noNumberUser.lastname);
            thirdname = browser.FindElement(By.Id("middlename_adult_1")); thirdname.SendKeys(noNumberUser.thirdname);
            birthdate = browser.FindElement(By.Id("birthdate_adult_1")); birthdate.SendKeys(noNumberUser.birthday);
            documentNumber = browser.FindElement(By.Id("docnumber_adult_1")); documentNumber.SendKeys(noNumberUser.birthday);
            phone = browser.FindElement(By.Id("phone")); phone.SendKeys(noNumberUser.phoneNumber);
            mail = browser.FindElement(By.Id("email")); mail.SendKeys(noNumberUser.mail);
            browser.FindElement(By.ClassName("btn-payment")).Click();
        }
        public void InputNoCardUserInfo()
        {
            name = browser.FindElement(By.Id("name_adult_1")); name.SendKeys(noCardUser.name);
            lastname = browser.FindElement(By.Id("surname_adult_1")); lastname.SendKeys(noCardUser.lastname);
            thirdname = browser.FindElement(By.Id("middlename_adult_1")); thirdname.SendKeys(noCardUser.thirdname);
            birthdate = browser.FindElement(By.Id("birthdate_adult_1")); birthdate.SendKeys(noCardUser.birthday);
            documentNumber = browser.FindElement(By.Id("docnumber_adult_1")); documentNumber.SendKeys(noCardUser.birthday);
            phone = browser.FindElement(By.Id("phone")); phone.SendKeys(noCardUser.phoneNumber);
            mail = browser.FindElement(By.Id("email")); mail.SendKeys(noCardUser.mail);
            browser.FindElement(By.ClassName("btn-payment")).Click();
        }
    }
}
