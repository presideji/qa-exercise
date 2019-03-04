using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using ValtechProject.Base;
using ValtechProject.Configs;

namespace ValtechProject.Pages
{
    public class LaunchHomePage : BasePage
    {
        private const string PageTitle = "Where Experiences are Engineered";

        public LaunchHomePage(RemoteWebDriver driver) : base(driver)
        {
            
        }

#region PageElements(Element Locators)

        public IWebElement AcceptCookiesElement => Driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));

        public IWebElement BlogbannerElement => Driver.FindElement(
                    By.CssSelector(
                        "#valtech-wrapper > div > main > div:nth-child(3) > div.block.bannerblock.col-lg-12.col-md-12.col-sm-12.col-xs-12 > div.banner-slider > div.banner-slider__indicator"));

        public IWebElement MenuBarElement => Driver.FindElement(By.CssSelector("body > nav > div.site-nav__icons > button.icon-menu"));

        public IWebElement ValtechAboutElement => Driver.FindElement(By.CssSelector("body > nav > div.site-nav__overlay > div.site-nav__overlay__content-general > div.site-nav__menu > div > ul.site-nav__menu__primary > li:nth-child(7) > button"));

        public IWebElement ValtechAboutThisIsUsElement => Driver.FindElement(By.CssSelector("body > nav > div.site-nav__overlay > div.site-nav__overlay__content-general > div.site-nav__main > div > div.site-nav__main__items.active > div:nth-child(2) > a"));

        public IWebElement ValtechServiElement
            => Driver.FindElement(By.CssSelector("body > nav > div.site-nav__overlay > div.site-nav__overlay__content-general > div.site-nav__menu > div > ul.site-nav__menu__primary > li:nth-child(3) > button"));

        public IWebElement ViewOurServicesElement
            =>
                Driver.FindElement(
                    By.CssSelector(
                        "body > nav > div.site-nav__overlay > div.site-nav__overlay__content-general > div.site-nav__main > div > div.site-nav__main__items.active > div:nth-child(2) > a"))
            ;
        
        public IWebElement AssertServicesElement
            =>
                Driver.FindElement(
                    By.CssSelector(
                        "#valtech-wrapper > div > main > div.masthead-secondary.masthead-scaler > div > div > div > div.masthead-secondary__text.masthead-secondary__text--light > hgroup > h1"))
            ;

        public IWebElement ViewAllOurWorkElement
            =>
                Driver.FindElement(
                    By.CssSelector(
                        "body > nav > div.site-nav__overlay > div.site-nav__overlay__content-general > div.site-nav__main > div > div.site-nav__main__items.active > div:nth-child(2) > a"))
            ;

        public IWebElement AssertWorkElement
            =>
                Driver.FindElement(
                    By.CssSelector("#valtech-wrapper > div > main > div.site-chapter > div > div.site-chapter__box > h1"))
            ;

        public IWebElement ContactUsElement => Driver.FindElement(By.XPath("/html/body/nav/div[2]/div[1]/div[3]/div/ul[2]/ul/li[3]/a"));

        
#endregion


#region Actions
        public void GoToValtechHomePage()
        {
            NavigateToUrl(Config.Default.ValtechHomePage);
            AcceptCookiesElement.Click();
        }

        public void PageTitlePresent()
        {
            var title = Driver.Title;
            Assert.AreEqual(title, PageTitle);
        }

        public void MenuBar()
        {
            MenuBarElement.Click();
        }

        public void About()
        {
            ValtechAboutElement.Click();
            ValtechAboutThisIsUsElement.Click();
        }

        //services
        public void ValtechServices()
        {
            ValtechServiElement.Click();
            ViewOurServicesElement.Click();
        }


        //work
        public void ValtechWork()
        {
            ViewAllOurWorkElement.Click();
        }

        //Contact Us
        public void ValtechContactUs()
        {
            ContactUsElement.Click();
        }

        //count list of countries
        public void ValtechOffices()
        {
            var officeList = Driver.FindElement(By.CssSelector("#valtech-wrapper > div > main > vue > div > div.masthead-contact.masthead-scaler > div > div > div.masthead-contact__nav > ul"))
            .FindElements(By.TagName("li")).Count();
            Console.WriteLine($"{officeList}");   

        }
        #endregion


        #region Assertions

        public bool InspectBlogBanner()
        {
            var blogBanner =
                Driver.FindElement(
                    By.CssSelector(
                        "#valtech-wrapper > div > main > div:nth-child(3) > div.block.bannerblock.col-lg-12.col-md-12.col-sm-12.col-xs-12 > div.banner-slider > div.banner-slider__indicator"));
            return true;

        }

        public bool AssertRecentBlog()
        {
            var recentblog1 =
                Driver.FindElement(
                    By.CssSelector(
                        "#valtech-wrapper > div > main > div:nth-child(3) > div.block.bannerblock.col-lg-12.col-md-12.col-sm-12.col-xs-12 > div.banner-slider > div.banner-slider__container > div > div.banner-slider__slide-items > div:nth-child(2) > video"));
                   return true;
           
        }

        public void AssertAboutPage()
        {
            var abouth1 = (Driver.FindElement(By.CssSelector("#valtech-wrapper > div > main > div.site-chapter > div > div.site-chapter__box > h1")));
            Assert.IsTrue(abouth1.Displayed);
        }
        
        public void AssertServicesPage()
        {
            var services = (Driver.FindElement(By.CssSelector("#valtech-wrapper > div > main > div.site-chapter > div > div.site-chapter__box > h1")));
            Assert.IsTrue(services.Displayed);
        }

        public void AssertWorkPage()
        {
            var work =
                (Driver.FindElement(
                    By.CssSelector("#valtech-wrapper > div > main > div.site-chapter > div > div.site-chapter__box > h1")));
            Assert.IsTrue(work.Displayed);
        }

        public void AssertContactUsPage()
        {
            var contactUs = (Driver.FindElement(By.CssSelector("#valtech-wrapper > div > main > div.site-chapter > div > div.site-chapter__box > h1")));
            Assert.IsTrue(contactUs.Displayed);
        }



        #endregion
    }
}
