using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows.Commands;
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
    public class SelectCommandTests
    {
        private SelectCommand _command;
        private Mock<IMessageBus> _mockMessageBus;
        private List<CanvasItem> _items;
        private CanvasItem _item;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _item = new FakeCanvasItem() { Id = 1 };
            _items = new List<CanvasItem> { _item };
            _row = new RowBuilder().WithId(1).Build();
            _rows = new List<Row> { _row };

            _mockMessageBus = new Mock<IMessageBus>();
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllRowsQuery>()))
                .Returns(_rows);

            _command = new SelectCommand(
                _mockMessageBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetSelectedRows()
        {
            _command.Execute(_items);
            _mockMessageBus.Verify(p => p.Execute(
                It.Is<SetSelectedRowsCommand>(q => q.Rows.Single() == _row)), Times.Once());
        }
    }
}
