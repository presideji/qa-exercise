QA exercise
==============================

Instructions instructions on how to set up and execute your tests on a clean install of Windows
===============================================================================================
Download and install Visual Studio 2017
https://visualstudio.microsoft.com/downloads/

After installing it configure and set it up using your preferences

Download and Install Reshaper
https://www.jetbrains.com/resharper/download/

After installing it configure and set it up using your preferences

Open Visual Studio and open a New Project

Decide on what type of test framework to use

Decide on what type of browser to use

Create another project as a  class library where you -test- will be located

Use reference manager and link the second project to the first project

On the Solution now begin to install your references
	Install NUnit
	Install NUnit3TestAdapter
	Install Selenium support
	Install Selenium Chrome Webdriver

On the second project install your references
	Install Specflow


Create your folders for proper structure
	In the first project create the folders below;
	- Base
	- Configs
	- DriverManager
	- Pages
	
	In the second project, create the folders below,
	- Create Browsers
	- Create Features
	- Create Hooks

In the "Configs" folder add the "settings". THis will add "Config.settings"
- Click on your "Config.settings" and configure the below
	- The web page - ValtechHomePage
	- Default time out - 60sec

	
Create a class in the DriverInstance folder
		- Code the remote driver
		
Create a class in the "Base" folder and in the class code in the below	
	- Inherit the "DriverInstance"
	- Write your page instances
	- Write Reusable methods

Create a class in the folder "Browser" and in the class code in the below
	- Inherit the "DriverInstance"
	- Create Methods to open and close browser


Create a class in the folder "TestHooks" and in the class code in the below
	- Inherit the "DriverInstance"
	- Create a method for container
	- Create a method for "Before" and "After" scenario
	
In the "Feature" folder add
	- add feature file
	- add step definitions
	
In the feature write - stories for the below	
	- Feature
	- Scenario

Then generate your "Step-Definition" copy it and paste it into the class


In your "Page" folder create a class and inherit the BasePage. Then write the below

	- Element Locators
	- Actions
	- Assertions


Call the drivers and methods in your step-definition

Enable the Test Explorer and Build the code


Run the Test





	