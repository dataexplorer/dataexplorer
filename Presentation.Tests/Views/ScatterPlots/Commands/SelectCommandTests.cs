using System.Collections.Generic;
using DataExplorer.Application.Rows;
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
        private Mock<IRowService> _mockService;
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

            _mockService = new Mock<IRowService>();
            _mockService.Setup(p => p.GetAll()).Returns(_rows);

            _command = new SelectCommand(
                _mockService.Object);
        }

        [Test]
        public void TestExecuteShouldSetSelectedRows()
        {
            _command.Execute(_items);
            _mockService.Verify(p => p.SetSelectedRows(_rows));
        }
    }
}
