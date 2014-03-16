Feature: ImportCsvFile
	As a user
	I want to import a CSV file
	So that I can explor CSV file data

@mytag
Scenario: Import a CSV File
	Given a CSV file source
	And a CSV file
	And the CSV file contains a column
	And the CSV file contains a row
	And a map exists for the the CSV file source
	When I import the CSV file source
	Then the CSV file column should be added to the repository
	And the CSV file row should be added to the repository
