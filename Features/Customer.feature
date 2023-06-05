Feature: Customer
	Validating customer page functionalities - creating a customer

@Customer
Scenario: Create a new customer
	Given I am on dashboard page
	And I click on create new button
	When I fill customer information
	And I click on create button
	Then The customer should be created and navigated to Dashboard page