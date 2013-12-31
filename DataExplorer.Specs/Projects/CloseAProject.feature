Feature: CloseAProject
	As a user
	I want to close a project
	So that I can reset the state of the application

@mytag
Scenario: Close a Project
	Given a CSV file source
	Given a column
	Given a row
	Given a scatterplot view
	When I close the project
	Then the source should be removed from the repository
	Then the column should be removed from the repository
	And the row should be removed from the repository
	And the scatterplot view should be removed from the repository
