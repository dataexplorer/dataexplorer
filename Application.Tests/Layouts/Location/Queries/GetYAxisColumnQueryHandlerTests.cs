using System.Windows;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Queries
{
    [TestFixture]
    public class GetYAxisColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetYAxisColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.YAxisColumn = _column;

            _handler = new GetYAxisColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetYAxisColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
