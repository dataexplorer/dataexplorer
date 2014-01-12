using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Projects
{
    [Binding]
    public class ProjectSteps
    {
        private readonly AppContext _appContext;

        public ProjectSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a project file")]
        public void GivenAProject()
        {
            _appContext.XProject = new XElement("Project");

            _appContext.MockXmlFileService.Setup(p => p.Load(@"C:\Project.xml"))
                .Returns(_appContext.XProject);
        }

        [Given(@"the project file has a source")]
        public void GivenTheProjectHasACSVFileSource()
        {
            var xSource = new XElement("sources", 
                new XElement("csv-file-source"),
                    new XElement("file-path", @"C:\Data.csv"));

            _appContext.XProject.Add(xSource);
        }

        [Given(@"the project file has a column")]
        public void GivenTheProjectHasAColumn()
        {
            var xColumn = new XElement("columns",
                new XElement("column",
                    new XElement("id", 1),
                    new XElement("index", 0),
                    new XElement("name", "Column 1"),
                    new XElement("type", "System.Object")));
            
            _appContext.XProject.Add(xColumn);
        }

        [Given(@"the project file has a row")]
        public void GivenTheProjectHasARow()
        {
            var xRow = new XElement("rows",
                new XElement("row",
                    new XElement("id", 1),
                    new XElement("fields")));

            _appContext.XProject.Add(xRow);
        }

        [Given(@"the project file has a filter")]
        public void GivenTheProjectFileHasAFilter()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the project file has a view")]
        public void GivenTheProjectHasAScatterplotView()
        {
            var xView = new XElement("views",
                new XElement("scatter-plot"));

            _appContext.XProject.Add(xView);
        }

        [Given(@"I select the project file to open")]
        public void GivenISelectTheProjectFileToOpen()
        {
            _appContext.MockDialogService.Setup(p => p.ShowOpenDialog())
                .Returns(@"C:\Project.xml");
        }
        
        [When(@"I open the project")]
        public void WhenIOpenTheProject()
        {
            _appContext.FileMenuViewModel.OpenCommand.Execute(null);
        }

        [When(@"I close the project")]
        public void WhenICloseTheProject()
        {
            _appContext.FileMenuViewModel.CloseCommand.Execute(null);
        }
    }
}
