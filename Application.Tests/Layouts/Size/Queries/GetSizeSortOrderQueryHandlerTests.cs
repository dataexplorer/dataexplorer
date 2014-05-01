using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Queries
{
    [TestFixture]
    public class GetSizeSortOrderQueryHandlerTests 
        : BaseGetLayoutSortOrderQueryHandlerTests
    {
        private GetSizeSortOrderQueryHandler _handler;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.SizeSortOrder = SortOrder.Descending;

            _handler = new GetSizeSortOrderQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSortOrder()
        {
            var result = _handler.Execute(new GetSizeSortOrderQuery());
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
