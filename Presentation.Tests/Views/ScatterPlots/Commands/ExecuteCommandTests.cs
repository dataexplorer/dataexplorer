using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Tests.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ExecuteCommandTests
    {
        private ExecuteCommand _command;
        private Mock<ICommandBus> _mockCommandBus;

        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();
            _command = new ExecuteCommand(
                _mockCommandBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetExecuteedRows()
        {
            _command.Execute(1);
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<Application.Views.ScatterPlots.Commands.ExecuteCommand>(q => q.Id == 1)), Times.Once());
        }
    }
}
