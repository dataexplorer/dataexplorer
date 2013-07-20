using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainWindow;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainWindow
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        [Test]
        public void TestConstructorShouldPopulateViewModels()
        {
            var mockViewerViewModel = new Moq.Mock<IViewerPaneViewModel>();
            var mainWindowViewModel = new MainWindowViewModel(mockViewerViewModel.Object);
            Assert.That(mainWindowViewModel.ViewerPaneViewModel, Is.EqualTo(mockViewerViewModel.Object));
        }
    }
}
