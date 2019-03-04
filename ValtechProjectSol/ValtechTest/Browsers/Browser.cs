using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using ValtechProject.DriverManager;

namespace ValtechTest.Browsers
{
    public class Browser : DriverInstance
    {
        public RemoteWebDriver LaunchBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            return Driver;

        }

        public void CloseBrowser()
        {
            try
            {
                Driver?.Close();
                Driver?.Quit();
                Driver?.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
