Feature: Employee
	User can perform CRUD operations on employee resource

@post
Scenario: User can add a new employee
	Given I create an employee with name 'Alex'
	Then Server returns 201
	And Name in response is 'Alex'

@get
Scenario: User can get an employee
	Given I have valid employee id
	When I get the employee by that id
	Then Correct employee is returned

@get
Scenario: User can get all employees
	Given There are no employees in the database
	And I create an employee with name 'One'
	And I create an employee with name 'Two'
	When I get all employees
	Then Two results are returned with names 'One' and 'Two'

@delete
Scenario: User can delete an employee by id
	Given I have valid employee id
	When I delete the employee with that id
	Then Employee is deleted

@put
Scenario: User can update an employee's salary
Given I have valid employee with salary '100'
When I update that employee's salary to '200'
Then Salary is changed to '200'