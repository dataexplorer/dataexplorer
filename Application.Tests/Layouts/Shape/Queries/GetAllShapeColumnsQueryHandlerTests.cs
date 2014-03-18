using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Layouts.Shape.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Shape.Queries
{
    [TestFixture]
    public class GetAllShapeColumnsQueryHandlerTests
        : BaseGetAllLayoutColumnsQueryHandlerTests
    {
        private GetAllShapeColumnsQueryHandler _handler;
        
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new GetAllShapeColumnsQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }
        
        [Test]
        [TestCase(typeof(BitmapImage))]
        public void TestExecuteShouldIncludeColumnTypes(Type type)
        {
            var column = new ColumnBuilder()
                .WithDataType(type)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllShapeColumnsQuery());
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }

        [Test]
        [TestCase(typeof(Boolean))]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(Double))]
        [TestCase(typeof(Int32))]
        [TestCase(typeof(String))]
        public void TestExecuteShouldExcludeColumnTypes(Type type)
        {
            var column = new ColumnBuilder()
                .WithDataType(type)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllShapeColumnsQuery());
            Assert.That(result, Is.Empty);
        }
    }
}
