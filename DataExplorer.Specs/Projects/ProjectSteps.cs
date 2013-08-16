﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Projects
{
    [Binding]
    public class ProjectSteps
    {
        private readonly Context _context;

        public ProjectSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a project")]
        public void GivenAProject()
        {
            var project = new Project();
            _context.Project = project;
            _context.MockSerializationService.Setup(p => p.GetProject()).Returns(project);
        }
        
        [Given(@"the project has a column")]
        public void GivenTheProjectHasAColumn()
        {
            var column = new Column(1, 0, "Column 1");
            var columns = new List<Column> { column };
            _context.Column = column;
            _context.Project.Columns = columns;
        }

        [Given(@"the project has a row")]
        public void GivenTheProjectHasARow()
        {
            var row = new Row();
            var rows = new List<Row> { row };
            _context.Row = row;
            _context.Project.Rows = rows;
        }

        [Given(@"the project has a scatterplot view")]
        public void GivenTheProjectHasAScatterplotView()
        {
            var scatterPlot = new ScatterPlot();
            var views = new List<IScatterPlot> { scatterPlot };
            _context.ScatterPlot = scatterPlot;
            _context.Project.ScatterPlot = scatterPlot;
        }

        [When(@"I open the project")]
        public void WhenIOpenTheProject()
        {
            _context.FileMenuViewModel.OpenCommand.Execute(null);
        }

        [Then(@"the column is added to the repository")]
        public void ThenTheColumnIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Columns.Single(), Is.EqualTo(_context.Column));
        }

        [Then(@"the row is added to the repository")]
        public void ThenTheRowIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Rows.Single(), Is.EqualTo(_context.Row));
        }

        [Then(@"the view is added to the repository")]
        public void ThenTheViewIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.ScatterPlot, Is.EqualTo(_context.ScatterPlot));
        }
    }
}
