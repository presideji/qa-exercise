using BoDi;
using TechTalk.SpecFlow;
using ValtechProject.DriverManager;
using ValtechTest.Browsers;

namespace ValtechTest.Hooks

{
    [Binding]
    public class TestHooks : DriverInstance
    {
        public ObjectContainer Container;
        public Browser Browser => new Browser();



        public TestHooks(ObjectContainer container)
        {
            Container = container;
        }




        [BeforeScenario]
        public void BeforeScenario(Browser browser)
        {
            Driver = browser.LaunchBrowser();
            Container.RegisterInstanceAs(Driver);
          
        }


        [AfterScenario]
        public void AfterScenario(Browser browser)
        {
           browser.CloseBrowser();
        }
    }


   
}
