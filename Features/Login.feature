Feature: Login
Login to Test Automation website

@LoginUser
Scenario: Login to Test Automation website
	Given I click on login url	
	When I type user credentials
	And I click on Login button
	Then Dashboard page should be displayed