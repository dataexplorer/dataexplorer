using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Shell.MainWindow;
using Ninject;
using Ninject.Extensions.Conventions;

namespace DataExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var kernel = InitializeDependencyInjection();

            InitializeShell(kernel);
        }

        private static StandardKernel InitializeDependencyInjection()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetCallingAssembly());
            kernel.Bind(p => p.FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InTransientScope()));
            return kernel;
        }

        private static void InitializeShell(StandardKernel kernel)
        {
            var mainWindow = kernel.Get<MainWindow>();
            var mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}
