using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Rows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Tests.Domain.Rows;
using DataExplorer.Tests.Presentation.Core.Canvas.Items;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Queries
{
    [TestFixture]
    public class GetSelectedItemsQueryTests
    {
        private GetSelectedItemsQuery _query;
        private Mock<IRowService> _mockRowService;
        private List<Row> _rows;
        private Row _row;
        private List<CanvasItem> _items;
        private FakeCanvasItem _item;

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().WithId(1).Build();
            _rows = new List<Row> { _row };
            _item = new FakeCanvasItem() { Id = 1 };
            _items = new List<CanvasItem> { _item };

            _mockRowService = new Mock<IRowService>();
            _mockRowService.Setup(p => p.GetSelectedRows()).Returns(_rows);

            _query = new GetSelectedItemsQuery(_mockRowService.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSelectedItems()
        {
            var results = _query.Execute(_items);
            Assert.That(results.Single(), Is.EqualTo(_item));
        }
    }
}
