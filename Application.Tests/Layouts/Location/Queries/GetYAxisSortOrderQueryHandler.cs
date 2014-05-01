using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Domain.Layouts;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Queries
{
    [TestFixture]
    public class GetYAxisSortOrderQueryHandlerTests
        : BaseGetLayoutSortOrderQueryHandlerTests
    {
        private GetYAxisSortOrderQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.YAxisSortOrder = SortOrder.Descending;

            _handler = new GetYAxisSortOrderQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSortOrder()
        {
            var result = _handler.Execute(new GetYAxisSortOrderQuery());
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
