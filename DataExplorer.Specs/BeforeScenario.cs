using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;
using Ninject;
using TechTalk.SpecFlow;
using Ninject.Extensions.Conventions;

namespace DataExplorer.Specs
{
    [Binding]
    public class BeforeScenario
    {
        private readonly Context _context;

        public BeforeScenario(Context context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void ExecuteBeforeScenario()
        {
            // TODO: Eliminate this duplication
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetAssembly(typeof(MainWindowViewModel)));
            kernel.Bind(p => p.From(Assembly.GetAssembly(typeof(MainWindowViewModel)))
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InTransientScope()));
            kernel.Load(Assembly.GetAssembly(typeof(Context)));
            kernel.Bind(p => p.FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InTransientScope()));

            _context.MockApplicationService = new Mock<IApplicationService>();
            kernel.Rebind<IApplicationService>().ToConstant(_context.MockApplicationService.Object);
            
            _context.MainWindowViewModel = kernel.Get<MainWindowViewModel>();
        }
    }
}
