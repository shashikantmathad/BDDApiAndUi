Feature: Calculator , Flight And Store Functionalities
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **sum** of ***two*** numbers

Link to a feature: [Calculator](SeleniumUi/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@flight @airasia
Scenario: SearchFlightsInAirAsia
	Given I Navigate to 'https://www.airasia.com/en/home.page'
	Then the page 'AirAsia India - Book Your Flights and Explore India' is displayed
	And Enter Details And Search Flights
	Then the page 'AirAsia India - Affordable Flights To Your Destination' is displayed

@login @airasia
Scenario Outline: ValidateLoginDialog
	Given I Navigate to 'https://www.airasia.com/en/home.page'
	Then the page 'AirAsia India - Book Your Flights and Explore India' is displayed
	And I Click on Login button
	And Enter Mobile number '<MobileNum>'
	Then Validate Login Window Panel with required header and links

	Examples:
		| TCName       | MobileNum  |
		| ValidMobileNum | 9902000000 |

@automationpractice
Scenario: RegisterToAutoPracticeStore
	Given I Navigate to 'http://automationpractice.com/index.php'
	Then the page 'My Store' is displayed
	Then I Click on Sign In Button
	And I Register New User