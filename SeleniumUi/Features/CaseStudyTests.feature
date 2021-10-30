Feature: Flight And Store Functionalities

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
		| TCName         | MobileNum  |
		| ValidMobileNum | 9902000000 |

@automationpractice
Scenario: RegisterToAutoPracticeStore
	Given I Navigate to 'http://automationpractice.com/index.php'
	Then the page 'My Store' is displayed
	Then I Click on Sign In Button
	And I Register New User