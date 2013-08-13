using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Persistence.Rows;
using DataExplorer.Persistence.Views;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;

namespace DataExplorer.Specs
{
    public class Context
    {
        public MainWindowViewModel MainWindowViewModel;
        public IFileMenuViewModel FileMenuViewModel;
        
        public Mock<IApplicationService> MockApplicationService;

        public IRowContext RowContext;
        public IViewContext ViewContext;
    }
}
