Feature: OpenAProject
	As a user
	I want to open a project
	So that I can work with a saved project

@mytag
Scenario: Open a Project
	Given a project file
	And the project file has a source
	And the project file has a column
	And the project file has a row
	And the project file has a filter
	And the project file has a view
	And I select the project file to open
	When I open the project
	Then the source should be added to the repository
	Then the column should be added to the repository
	Then the row should be added to the repository
	Then the filter should be added to the repository
	Then the view should be added to the repository
	
