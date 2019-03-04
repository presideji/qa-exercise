Feature: ValtechBlog
	As a customer
	I want to be able to access Valtech website
	So that I can view the recent blogs

@ValtechHomepage
Scenario: Navigate To Homepage
	Given I am on the HomePage
	When I inspect the blog banner
	And the recent blog should be displayed
	Then I can see the page title is present

@ValAbout
Scenario: About Valtech
	Given I am on the HomePage
	When I click menu tab
	And I click about tab
	Then about page should display

@ValWork
Scenario: Work
	Given I am on the HomePage
	When I click menu tab
	And I click work tab
	Then work page should display


@ValServices
Scenario: Services
	Given I am on the HomePage
	When I click menu tab
	And I click services button
	Then services page should display

@ValContactUs
Scenario: ContactUs
	Given I am on the HomePage
	When I click menu tab
	And I Click Contact Us
	Then Contact page should display
	And I output how many Valtech offices in total
