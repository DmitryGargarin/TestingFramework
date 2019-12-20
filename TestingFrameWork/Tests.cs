using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TestingFrameWork.Pages;
using TestingFrameWork.Utilits;

namespace TestingFrameWork
{
    [TestFixture]
    public class FrameworkTests
    {
        private IWebDriver browser;
        [SetUp]
        public void OpenBrowserAndGoToWebSite()
        {
            browser = Driver.Driver.SetDriver();
            browser.Navigate().GoToUrl("http://gsv.aero");
            browser.FindElement(By.ClassName("js-cookies-message__close")).Click();
        }

        // Купить билет на самолёт в одну сторону
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать кнопку "Купить билеты"
        //3) Ввести "Москва" в текстовое поле "город вылета"
        //4) Ввести "Санкт-Петербург" в текстовое поле "город прибытия"
        //5) Указать "12.10.2019" в поле "дата вылета"
        //6) Указать количество пассажиров("1 взрослый")
        //7) Нажать кнопку "Найти билеты"
        //8) Выбрать первый билет из списка
        //9) Ввести ФИО("Gargarin Dmitry"), дату рождения(25.05.2000), паспортные данные(МР3803818), телефон(+375292783083), 
        //электронную почту("dgargarin@mail.ru") в соответствующих полях; нажать кнопку "Перейти к оплате"
        //10) Ввести номер карты(4255 2003 0160 1662), срок годности(02/20), имя владельца карты(INSTANT CARD) и защитный код(228); нажать кнопку "Купить"
        //Фактический результат: вывод статуса оплаты билета("Заказ не оплачен")

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

        //Перевести веб-приложение с русского языка на английский
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать сверху на кнопку "EN"
        //Фактический результат: объекты на сайте(меню, различные кнопки и т.д.) переведены на английский; переведено не 
        [Test]
        public void TranslateWebSiteToEnglish()
        {
            browser.FindElement(By.ClassName("hdr-link--lang")).Click();
            Assert.IsTrue(browser.FindElement(By.TagName("html")).GetAttribute("lang") == "en");
        }

        //Ознакомиться с информацией об аэропорте
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать кнопку "Партнёрам"
        //3) Нажать кнопку "Об аэропорте"
        //4) Прокрутить вниз
        //Фактический результат: окно с информацией об аэропорте(описание, площадь аэропорта, дополнительная информация).
        [Test]
        public void TakeAirportInfo()
        {
            MainPage mainPage = new MainPage(browser);
            PartnersPage partnersPage = mainPage.PartnersPageButtonClick();
            partnersPage.MoveToAboutPageButton();
            AboutPage aboutPage = partnersPage.AboutPageButtonClick();
            Assert.IsTrue(browser.Url == "https://gsv.aero/partners/about/airport-today/");
        }
        //Ввод пустых данных в поле окна бронирования VIP-зала
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать кнопку "VIP-зал"
        //3) Вписать в поле "ФИО" "Гаргарин Дмитрий Станиславович", не заполнять поле "Телефон"
        //4) Прокрутить вниз, нажать "Отправить заявку"
        //Фактический результат: выведено окно о тех полях, которые не заполнены; заполненные данные не сбрасываются.
        [Test]
        public void InputEmptyValuesInVipPage()
        {
            Listener.MakeScreenshotWhenFail(() =>
                {
                    MainPage mainPage = new MainPage(browser);
                    VipPage vipPage = mainPage.VipPageButtonClick();
                    vipPage.ServeButtonClick();
                    vipPage.InsertTextInNameField("Гаргарин Дмитрий Станиславович");
                }
            );


        }

        //Перейти в окно покупки билета через поиск
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать на кнопку лупы в верхней части экрана
        //3) Ввести "Купить билет" в текстовом поле
        //4) Нажать кнопку "Поиск"
        //Фактический результат: список вариантов, подходящие под запрос поиска.
        [Test]
        public void BuyTicketPageThroughSearchWindow()
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

        //Забронировать гостиницу
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать кнопку "Прилёт"
        //3) Нажать кнопку "Гостиницы"
        //4) Выбрать первый вариант из списка
        //5) Нажать кнопку "Бронирование"
        //Фактический результат: переход на сайт гостиницы и бронирование уже там.
        [Test]
        public void ServeHotel()
        {
            MainPage mainPage = new MainPage(browser);
            ArrivalPage arrivalPage = mainPage.ArrivalPageButtonClick();
            HotelPage hotelPage = arrivalPage.HotelPageButtonClick();
            hotelPage.ChooseHotel();
            Assert.IsTrue(browser.Url == "http://www.hotelslovakia.ru/bronirovanie/");
        }
        //Изменить внешний вид сайта
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать на иконку очков в верхней части(рядом с иконкой лупы)
        //3) Выбрать размер шрифта "Большой", изменить цветовую схему на чёрно-белую
        //Фактический результат: сайт сменил цвет с синего на чёрный, шрифт стал больше.
        [Test]
        public void ChangeAppearanceOfWebSite()
        {
            MainPage mainPage = new MainPage(browser);
            mainPage.MoveToChangeAppearanceButton();
            mainPage.ChangeAppearanceButtonClick();
            mainPage.ChangeFontSize();
            mainPage.ChangeThemeColor();
            Assert.IsTrue(browser.FindElement(By.TagName("html")).GetAttribute("class").Contains("theme-font-lg theme-color-blind"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
