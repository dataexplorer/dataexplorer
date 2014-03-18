using System.Windows;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Queries
{
    [TestFixture]
    public class GetXAxisColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetXAxisColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.XAxisColumn = _column;

            _handler = new GetXAxisColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetXAxisColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
