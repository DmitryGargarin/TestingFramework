using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TestingFrameWork.Models;
using TestingFrameWork.Pages;
using TestingFrameWork.Utilits;

namespace TestingFrameWork
{
    [TestFixture]
    public class FrameworkTests
    {
        private IWebDriver browser;
        private UserModel user = UserModel.DefaultUser();
        [SetUp]
        public void OpenBrowserAndGoToWebSite()
        {
            browser = Driver.Driver.SetDriver();
            browser.Navigate().GoToUrl("http://gsv.aero");
            browser.FindElement(By.ClassName("js-cookies-message__close")).Click();
        }

        [Test]
        public void BuyTicketDefaultUser()
        {
            Listener.MakeScreenshotWhenFail(() =>
                {
                    MainPage mainPage = new MainPage(browser);
                    BuyTicketPage buyTicketPage = mainPage.BuyTicketPageButtonClick();
                    buyTicketPage.InputFlightInfo();
                    buyTicketPage.PickAirplane();
                    buyTicketPage.InputDefaultUserInfo();
                    Assert.IsTrue(browser.FindElement(By.ClassName("stayhere")).Displayed);
                }
           );

        }
        [Test]
        public void BuyTicketNoNumberUser()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                BuyTicketPage buyTicketPage = mainPage.BuyTicketPageButtonClick();
                buyTicketPage.InputFlightInfo();
                buyTicketPage.PickAirplane();
                buyTicketPage.InputNoNumberUserInfo();
                Assert.IsTrue(browser.FindElement(By.ClassName("stayhere")).Displayed);
            }
           );

        }
        [Test]
        public void BuyTicketNoCardUser()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                BuyTicketPage buyTicketPage = mainPage.BuyTicketPageButtonClick();
                buyTicketPage.InputFlightInfo();
                buyTicketPage.PickAirplane();
                buyTicketPage.InputNoCardUserInfo();
                Assert.IsTrue(browser.FindElement(By.ClassName("stayhere")).Displayed);
            }
           );

        }
        [Test]
        public void TranslateWebSiteToEnglish()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                browser.FindElement(By.ClassName("hdr-link--lang")).Click();
                Assert.IsTrue(browser.FindElement(By.TagName("html")).GetAttribute("lang") == "en");
            });
           
        }
        [Test]
        public void TakeAirportInfo()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                PartnersPage partnersPage = mainPage.PartnersPageButtonClick();
                partnersPage.MoveToAboutPageButton();
                AboutPage aboutPage = partnersPage.AboutPageButtonClick();
                Assert.IsTrue(browser.Url == "https://gsv.aero/partners/about/airport-today/");
            });
        }
        [Test]
        public void InputEmptyValuesInVipPage()
        {
            Listener.MakeScreenshotWhenFail(() =>
                {
                    MainPage mainPage = new MainPage(browser);
                    VipPage vipPage = mainPage.VipPageButtonClick();
                    vipPage.ServeButtonClick();
                    vipPage.InsertTextInNameField(user.lastname + " " + user.name + " " + user.thirdname);
                    vipPage.SendInfoButtonClick();
                    Assert.IsTrue(browser.FindElement(By.ClassName("popup-shell")).Displayed);
                }
            );


        }
        [Test]
        public void BuyTicketPageThroughSearchWindow()
        {
           
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                SearchPage searchPage = mainPage.SearchButtonClick();
                searchPage.InsertTextInSearchField("Купить билеты");
                searchPage.MoveToSearchButton();
                new WebDriverWait(browser, TimeSpan.FromSeconds(5));
                searchPage.SearchButtonClick();
                searchPage.GetFirstAnswerAndGoToUrl();
                Assert.IsTrue(browser.Url == "https://gsv.aero/services/booking-tickets/");
            }
            );
        }
        [Test]
        public void ServeHotel()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                ArrivalPage arrivalPage = mainPage.ArrivalPageButtonClick();
                HotelPage hotelPage = arrivalPage.HotelPageButtonClick();
                hotelPage.ChooseHotel();
                Assert.IsTrue(browser.Url == "http://www.hotelslovakia.ru/bronirovanie/");
            }
           );
            
        }
        [Test]
        public void ChangeAppearanceOfWebSite()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                mainPage.MoveToChangeAppearanceButton();
                mainPage.ChangeAppearanceButtonClick();
                mainPage.ChangeFontSize();
                mainPage.ChangeThemeColor();
                Assert.IsTrue(browser.FindElement(By.TagName("html")).GetAttribute("class").Contains("theme-font-lg theme-color-blind"));
            }
          );
        }
        [Test]
        public void FindSchemeOfAirportFromPartners()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                PartnersPage partnersPage = mainPage.PartnersPageButtonClick();
                partnersPage.MoveToAboutPageButton();
                BusinessHallPage schemePage = partnersPage.SchemePageButtonClick();
                Assert.IsTrue(browser.Url == "https://gsv.aero/scheme/"); }
          );
        }
        [Test]
        public void FindRulesFromMenu()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(browser);
                mainPage.MenuButtonClick();
                mainPage.RulesButtonClick();
                Assert.IsTrue(browser.Url == "https://gsv.aero/rules/tamozhennyy-kontrol-/");
            }
          );
        }
        [Test]
        public void GoToBusinessHallPage()
        {
            MainPage mainPage = new MainPage(browser);
            BusinessHallPage businessHallPage = mainPage.BusinessHallPageButtonClick();
            Assert.IsTrue(browser.Url == "https://gsv.aero/services/businesshall/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
