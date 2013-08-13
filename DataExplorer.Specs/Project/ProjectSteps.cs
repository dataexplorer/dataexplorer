using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Project
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
            ScenarioContext.Current.Pending();
        }

        [When(@"I open the project")]
        public void WhenIOpenTheProject()
        {
            _context.FileMenuViewModel.OpenCommand.Execute(null);
        }

        [Then(@"the columns are added to the repository")]
        public void ThenTheColumnsAreAddedToTheRepository()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the rows are added to the repository")]
        public void ThenTheRowsAreAddedToTheRepository()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the views are added to the repository")]
        public void ThenTheViewsAreAddedToTheRepository()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
