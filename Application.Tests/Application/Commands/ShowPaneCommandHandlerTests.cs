using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Commands;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Application.Commands
{
    [TestFixture]
    public class ShowPaneCommandHandlerTests
    {
        private ShowPaneCommandHandler _handler;
        private Mock<IEventBus> _mockEventBus;

        [SetUp]
        public void SetUp()
        {
            _mockEventBus = new Mock<IEventBus>();

            _handler = new ShowPaneCommandHandler(
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldRaisePaneVisibilityChangedEvent()
        {
            _handler.Execute(new ShowPaneCommand(Pane.Navigation));

            _mockEventBus.Verify(p => p.Raise(
                It.Is<PaneVisibilityChangedEvent>(q => 
                    q.Pane == Pane.Navigation 
                        && q.IsVisible == true)), 
                Times.Once());
        }
    }
}
