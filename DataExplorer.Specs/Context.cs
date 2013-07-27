using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;

namespace DataExplorer.Specs
{
    public class Context
    {
        public MainWindowViewModel MainWindowViewModel;
        public Mock<IApplicationService> MockApplicationService;
    }
}
