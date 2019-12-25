using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TestingFrameWork.Driver;
using TestingFrameWork.Models;
using TestingFrameWork.Pages;
using TestingFrameWork.Utilits;
using TestingFrameWork.Loggers;

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
            Logger.InitLogger();
            browser = DriverSingleton.SetDriver();
            DriverSingleton.PrepareDriverToWork(browser);
            Logger.Log.Info("Driver is ready");
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
                    buyTicketPage.InputUserInfo(user);
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
                Assert.AreEqual("en", browser.FindElement(By.TagName("html")).GetAttribute("lang"));
            });
           
        }
        [Test]
        public void TakeAirportInfo()
        {
            Listener.MakeScreenshotWhenFail(() =>
            {
                Logger.Log.Info("TakeAirportInfo() test started");
                MainPage mainPage = new MainPage(browser);
                PartnersPage partnersPage = mainPage.PartnersPageButtonClick();
                partnersPage.MoveToAboutPageButton();
                AboutPage aboutPage = partnersPage.AboutPageButtonClick();
                Assert.AreEqual("https://gsv.aero/partners/about/airport-today/", browser.Url);
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
                Assert.AreEqual("https://gsv.aero/services/booking-tickets/", browser.Url);
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
                Assert.AreEqual("http://www.hotelslovakia.ru/bronirovanie/", browser.Url);
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
            Assert.AreEqual("https://gsv.aero/services/businesshall/", browser.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverSingleton.CloseBrowser();
        }
    }
}
