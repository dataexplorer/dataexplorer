using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Projects;
using DataExplorer.Infrastructure.Importers.CsvFile;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.XmlFiles;
using DataExplorer.Persistence;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Importers.CsvFile;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
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
        private readonly AppContext _appContext;

        public BeforeScenario(AppContext appContext)
        {
            _appContext = appContext;
        }

        [BeforeScenario]
        public void ExecuteBeforeScenario()
        {
            // TODO: Eliminate this duplication
            var kernel = new StandardKernel();
            kernel.Load("DataExplorer*.dll");
            kernel.Bind(p => p.FromAssembliesMatching("DataExplorer*.dll")
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));
            kernel.Load(Assembly.GetAssembly(typeof(AppContext)));
            kernel.Bind(p => p.FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));

            _appContext.MockApplication = new Mock<IApplication>();
            kernel.Rebind<IApplication>().ToConstant(_appContext.MockApplication.Object);

            _appContext.MockDialogService = new Mock<IDialogService>();
            kernel.Rebind<IDialogService>().ToConstant(_appContext.MockDialogService.Object);

            _appContext.MockXmlFileService = new Mock<IXmlFileService>();
            kernel.Rebind<IXmlFileService>().ToConstant(_appContext.MockXmlFileService.Object);

            _appContext.MockCsvFileParser = new Mock<ICsvFileParser>();
            kernel.Rebind<ICsvFileParser>().ToConstant(_appContext.MockCsvFileParser.Object);

            _appContext.MainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _appContext.FileMenuViewModel = kernel.Get<IFileMenuViewModel>();
            _appContext.CsvFileImportViewModel = kernel.Get<ICsvFileImportViewModel>();

            _appContext.DataContext = kernel.Get<IDataContext>();

            CommandBus.Kernel = kernel;
            QueryBus.Kernel = kernel;
            EventBus.Kernel = kernel;
        }
    }
}
