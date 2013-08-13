Feature: OpenAProject
	As a user
	I want to open a project
	So that I can work with a saved project

@mytag
Scenario: Open a Project
	Given a project
	When I open the project
	Then the columns are added to the repository
	Then the rows are added to the repository
	Then the views are added to the repository
	
