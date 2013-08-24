Feature: OpenAProject
	As a user
	I want to open a project
	So that I can work with a saved project

@mytag
Scenario: Open a Project
	Given a project
	And the project has a CSV file source
	And the project has a column
	And the project has a row
	And the project has a scatterplot view
	When I open the project
	Then the CSV file source is added to the repository
	Then the column is added to the repository
	Then the row is added to the repository
	Then the view is added to the repository
	
