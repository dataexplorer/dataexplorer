using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Commands;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Rows.Commands
{
    [TestFixture]
    public class SetSelectedRowsCommandHandlerTests
    {
        private SetSelectedRowsCommandHandler _handler;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IEventBus> _mockEventBus;
        private List<Row> _rows;
        private Row _row;
            
        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };

            _mockStateService = new Mock<IApplicationStateService>();

            _mockEventBus = new Mock<IEventBus>();

            _handler = new SetSelectedRowsCommandHandler(
                _mockStateService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetSelectedRowsInStateService()
        {
            _handler.Execute(new SetSelectedRowsCommand(_rows));
            _mockStateService.Verify(p => p.SetSelectedRows(_rows));
        }

        [Test]
        public void TestExecuteShouldRaiseSelectedRowsChangedEvent()
        {
            _handler.Execute(new SetSelectedRowsCommand(_rows));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SelectedRowsChangedEvent>()), Times.Once());
        }
    }
}
