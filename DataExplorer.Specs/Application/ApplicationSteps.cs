using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Application
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly AppContext _appContext;

        public ApplicationSteps(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        [When(@"I exit the application")]
        public void WhenIExitTheApplication()
        {
            _appContext.FileMenuViewModel.ExitCommand.Execute(null);
        }

        [Then(@"the application should shut down")]
        public void ThenTheApplicationShouldShutDown()
        {
            _appContext.MockApplication.Verify(p => p.ShutDown(), Times.Once());
        }

    }
}
