using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Domain.Layouts;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Color.Queries
{
    [TestFixture]
    public class GetColorSortOrderQueryHandlerTests
        : BaseGetLayoutSortOrderQueryHandlerTests
    {
        private GetColorSortOrderQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.ColorSortOrder = SortOrder.Descending;

            _handler = new GetColorSortOrderQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSortOrder()
        {
            var result = _handler.Execute(new GetColorSortOrderQuery());
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
