using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
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

        [Given(@"the project has a CSV file source")]
        public void GivenTheProjectHasACSVFileSource()
        {
            var source = new CsvFileSource();
            var sources = new List<ISource> { source };
            _context.CsvFileSource = source;
            _context.Project.Sources = sources;
        }

        [Given(@"the project has a column")]
        public void GivenTheProjectHasAColumn()
        {
            var column = new ColumnBuilder().Build();
            var columns = new List<Column> { column };
            _context.Column = column;
            _context.Project.Columns = columns;
        }

        [Given(@"the project has a row")]
        public void GivenTheProjectHasARow()
        {
            var row = new RowBuilder().Build();
            var rows = new List<Row> { row };
            _context.Row = row;
            _context.Project.Rows = rows;
        }

        [Given(@"the project has a scatterplot view")]
        public void GivenTheProjectHasAScatterplotView()
        {
            var scatterPlot = new ScatterPlot();
            var views = new List<IView> { scatterPlot };
            _context.ScatterPlot = scatterPlot;
            _context.Project.DataViews = views;
        }

        [When(@"I open the project")]
        public void WhenIOpenTheProject()
        {
            _context.FileMenuViewModel.OpenCommand.Execute(null);
        }

        [When(@"I close the project")]
        public void WhenICloseTheProject()
        {
            _context.FileMenuViewModel.CloseCommand.Execute(null);
        }
    }
}
