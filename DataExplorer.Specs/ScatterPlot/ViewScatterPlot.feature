Feature: ViewScatterPlot
	As a user
	I want to view a scatter plot of data
	So that I can visualize two dimensions of my data

@mytag
Scenario: Single Point at (0,0)
	Given the following data set:
		| x | y |
		| 0 | 0 |
	And the x-axis is mapped to the "x" column
	And the y-axis is mapped to the "y" column
	When I refresh the scatterplot
	Then a single point should be displayed at (0,0)
