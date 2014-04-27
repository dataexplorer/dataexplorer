using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Queries
{
    [TestFixture]
    public class GetXAxisSortOrderQueryHandlerTests 
        : BaseGetLayoutSortOrderQueryHandlerTests
    {
        private GetXAxisSortOrderQueryHandler _handler;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.XAxisSortOrder = SortOrder.Descending;

            _handler = new GetXAxisSortOrderQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnSortOrder()
        {
            var result = _handler.Execute(new GetXAxisSortOrderQuery());
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
