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
        private readonly Context _context;

        public ApplicationSteps(Context context)
        {
            _context = context;
        }
        
        [When(@"I exit the application")]
        public void WhenIExitTheApplication()
        {
            _context.MainWindowViewModel.MainMenuViewModel.FileMenuViewModel.ExitCommand.Execute(null);
        }

        [Then(@"the application should shut down")]
        public void ThenTheApplicationShouldShutDown()
        {
            _context.MockApplicationService.Verify(p => p.Exit(), Times.Once());
        }

    }
}
