using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Layouts.Shape.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Shape.Queries
{
    [TestFixture]
    public class GetShapeColumnQueryHandlerTests 
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetShapeColumnQueryHandler _handler;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.ShapeColumn = _column;

            _handler = new GetShapeColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetShapeColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
