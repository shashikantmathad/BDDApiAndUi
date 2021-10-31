Feature: API SmokeTestCases

@mytag
Scenario: Create Users
	Given i use the endpoint api/users
	When i create the POST method using {    "name": "morpheus",    "job": "leader"}
	And i send the request
	Then the respose is successful

Scenario: Create Users using model
	Given i use the endpoint api/users
	When i create the request
		| key  | value    |
		| name | mark     |
		| job  | employee |
	And i send the request
