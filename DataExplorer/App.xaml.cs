using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.Events;
using DataExplorer.Presentation.Shell.MainWindow;
using Ninject;
using Ninject.Extensions.Conventions;

namespace DataExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static IKernel _kernel;

        public App()
        {
            InitializeDependencyInjection();

            InitializeEvents();

            InitializeShell();
        }

        private static void InitializeDependencyInjection()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetCallingAssembly());
            _kernel.Bind(p => p.FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));
        }

        private static void InitializeEvents()
        {
            EventBus.Kernel = _kernel;
            DomainEvents.Kernel = _kernel;
        }
        
        private static void InitializeShell()
        {
            var mainWindow = _kernel.Get<MainWindow>();
            var mainWindowViewModel = _kernel.Get<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}
