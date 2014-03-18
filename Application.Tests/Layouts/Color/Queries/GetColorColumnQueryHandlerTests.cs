using System;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Color.Queries
{
    [TestFixture]
    public class GetColorColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetColorColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.ColorColumn = _column;

            _handler = new GetColorColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetColorColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
