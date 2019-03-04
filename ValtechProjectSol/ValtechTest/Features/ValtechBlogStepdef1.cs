using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using ValtechProject.Base;
using ValtechProject.Pages;

namespace ValtechTest.Features
{
    [Binding]
    public class ValtechBlogStepdef1 : BasePage
    {
       

        public ValtechBlogStepdef1(RemoteWebDriver driver) : base(driver)
        {
            
        }
        [Given(@"I am on the HomePage")]
        public void GivenIAmOnTheHomePage()
        {
            LaunchHomePage.GoToValtechHomePage();
        }

        [When(@"I inspect the blog banner")]
        public void WhenIInspectTheBlogBanner()
        {
            Assert.IsTrue(new LaunchHomePage(Driver).InspectBlogBanner());
        }

        [When(@"the recent blog should be displayed")]
        public void WhenTheRecentBlogShouldBeDisplayed()
        {
            Assert.IsTrue(new LaunchHomePage(Driver).AssertRecentBlog());
        }

        [Then(@"I can see the page title is present")]
        public void ThenICanSeeThePageTitleIsPresent()
        {
            LaunchHomePage.PageTitlePresent();
        }


        //** Pages - About **//
        [When(@"I click menu tab")]
        public void WhenIClickMenuTab()
        {
            LaunchHomePage.MenuBar();
        }

        [When(@"I click about tab")]
        public void WhenIClickAboutTab()
        {
            LaunchHomePage.About();
        }

        [Then(@"about page should display")]
        public void ThenAboutPageShouldDisplay()
        {
            LaunchHomePage.AssertAboutPage();
        }

        //services

        [When(@"I click services button")]
        public void WhenIClickServicesButton()
        {
            LaunchHomePage.ValtechServices();
        
        }

        [Then(@"services page should display")]
        public void ThenServicesPageShouldDisplay()
        {
            LaunchHomePage.AssertServicesPage();
        }

        //Work
        [When(@"I click work tab")]
        public void WhenIClickWorkTab()
        {
            LaunchHomePage.ValtechWork();
        }

        [Then(@"work page should display")]
        public void ThenWorkPageShouldDisplay()
        {
           LaunchHomePage.AssertWorkPage();
        }

        // Contact Us
        [When(@"I Click Contact Us")]
        public void WhenIClickContactUs()
        {
            LaunchHomePage.ValtechContactUs();
        }

        [Then(@"Contact page should display")]
        public void ThenContactPageShouldDisplay()
        {
            LaunchHomePage.AssertContactUsPage();
        }

        [Then(@"I output how many Valtech offices in total")]
        public void ThenIOutputHowManyValtechOfficesInTotal()
        {
            LaunchHomePage.ValtechOffices();
        }


    }
}
