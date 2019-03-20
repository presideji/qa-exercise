using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Configuration;
using ValtechProject.DriverManager;
using ValtechTest.Browsers;
using ValtechProject.Configs;

namespace ValtechTest.Hooks

{
    [Binding]
    public class TestHooks : DriverInstance
    {
        public ObjectContainer Container;
        public Browser Browser => new Browser();
        public string BrowserName = Config.Default.ChromeBrowser;


        public TestHooks(ObjectContainer container)
        {
            Container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                Process.Start("taskkill", "/F /IM chromedriver.exe");
                //Process.Start("taskkill", "/F /IM chrome.exe");
                Process.Start("taskkill", "/F /IM IEDriverServer.exe");
                Process.Start("taskkill", "/F /IM IEDriverServer64.exe");
                //Process.Start("taskkill", "/F /IM firefox.exe");
            }

            catch (Exception e)
            {
                Console.WriteLine("Browser is not closed properly" + e.Message);
            }
        }

        public void TakeScreenShot()
        {
            //var time = DateTime.Now;


            //// Generic Solution Path 
            ////var path = Assembly.GetCallingAssembly().CodeBase;
            ////var actualPath = path.Substring(0, path.LastIndexOf("bin", StringComparison.Ordinal));
            ////var projectPath = new Uri(actualPath).LocalPath;

            //var dateTimeNow = "_" + time.ToString("dd-MM-yyyy") + "_" + time.ToString("HH-mm-ss") + "_";
            //var nameOfFailedTest = TestContext.CurrentContext.Test.MethodName;

            //try
            //{
            //    if (TestContext.CurrentContext.Result.Outcome == ResultState.Success) return;
            //    {
            //        var screenshot = Driver.GetScreenshot();
            //        screenshot.SaveAsFile(Config.Default.Screenshot + "automationScreenShot\\" + nameOfFailedTest + dateTimeNow + "screenshot.jpeg",
            //        ScreenshotImageFormat.Jpeg);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e + "screenshot was not taken");
            //    throw;
            //}

        }

        [BeforeScenario]
        public void BeforeScenario(Browser browser)
        {
            Driver = browser.LaunchBrowser(BrowserName);
            Container.RegisterInstanceAs(Driver);
          
        }


        [AfterScenario]
        public void AfterScenario(Browser browser)
        {
           //TakeScreenShot();
           browser.CloseBrowser();
            
        }
    }


   
}
