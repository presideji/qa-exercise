using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using ValtechProject.Configs;
using ValtechProject.DriverManager;
using ValtechProject.Pages;

namespace ValtechProject.Base
{
    public class BasePage : DriverInstance
    {
        public BasePage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public string ValtechHomepage = Config.Default.ValtechHomePage;


#region page instances
        

        public LaunchHomePage LaunchHomePage => new LaunchHomePage(Driver);
#endregion
       
        
        //** Reusable Actions **//
        public IWebElement Element;
        public Actions Actions => new Actions(Driver);
        public Random Random => new Random();
        public SelectElement SelectElement => new SelectElement(Element);
        public int DefaultTime = Config.Default.DefaultTimeOuts;

#region Reusable Methods

        //** Wait for element **//
        public bool CheckElementPresent(IWebElement ele)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(IsElementPresent(ele));
        }

        //** Check for element visibility **//
        public Func<IWebDriver, bool> IsElementPresent(IWebElement element)
        {
            return driver => element.Displayed;
        }

        //** Send Keys to Fields **//
        public void SendKeysTo(IWebElement element, string text)
        {
            CheckElementPresent(element);
            element.Clear();
            element.SendKeys(text);
        }


        //** Click on Elements **//
        public void ClickOn(IWebElement element)
        {
            CheckElementPresent(element);
            element.Click();
            WaitForPageLoad();
        }


        //** Mouse hover action **//
        public void HoverOnElement(IWebElement element)
        {
            Actions.MoveToElement(element).Build().Perform();
            WaitForPageLoad();
        }


        //** Click on Submit buttons **//
        public void ClickSubmitButton(IWebElement element)
        {
            element.Submit();
            WaitForPageLoad();
        }


        //** Navigate to url **//
        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoad();
            WaitForAWhile(DefaultTime);
        }


        //** Implicit wait for few seconds **//
        public void WaitForAWhile(int value)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value);
        }


        //** Explicit Wait **//
        public void WaitForFewSeconds(int value)
        {
            Thread.Sleep(value);
        }


        //** Wait for page load **//
        public void WaitForPageLoad()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTime));
            wait.Until(driver1 =>
                ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }


        //** Get all Cookies check contains "cookieName" **//
        public void CheckCookiesContains(string cookie)
        {
            var allCookies = Driver.Manage().Cookies.AllCookies;
            Assert.True(allCookies.ToString().Contains(cookie));
        }


        //** Delete all cookies **//
        public void DeleteAllCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }


        //** Select element by text **//
        public void SelectElementByText(IWebElement element, string text)
        {
            Element = element;
            CheckElementPresent(element);
            SelectElement.SelectByText(text);
        }


        //** Select element by Value **//
        public void SelectElementByValue(IWebElement element, string value)
        {
            Element = element;
            SelectElement.SelectByValue(value);
        }


        //** Select element by index **//
        public void SelectElementByIndex(IWebElement element, int index)
        {
            Element = element;
            SelectElement.SelectByIndex(index);
        }


        public void SelectElementByLastIndex(IWebElement element)
        {
            Element = element;
            SelectElement.SelectByIndex(new Random().Next(SelectElement.Options.Count - 1));
        }


        //** Check if url contains a given value **//
        public bool CheckUrlContains(string value)
        {
            var url = Driver.Url;
            return url.Contains(value.ToLower());
        }




#endregion





    }
}
