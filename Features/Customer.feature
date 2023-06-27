Feature: Customer
	Validating customer page functionalities - Creating a customer

@Customer
Scenario: Create a new customer
	Given I am on the dashboard page
	And I click on the create new button
	When I fill the customer information
	And I click on the create button
	Then The customer should be created and navigated to "Dashboard" page 