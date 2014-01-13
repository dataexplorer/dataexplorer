using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Maps.Queries
{
    [TestFixture]
    public class GetAxisMapQueryHandlerTests
    {
        private GetAxisMapQueryHandler _handler;
        private Mock<IColumnRepository> _mockRepository;
        private Mock<IMapFactory> _mockFactory;
        private Column _column;
        private ColumnDto _columnDto;
        private FakeAxisMap _axisMap;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _columnDto = new ColumnDto() { Id = 1 };
            _axisMap = new FakeAxisMap();

            _mockRepository = new Mock<IColumnRepository>();
            _mockRepository.Setup(p => p.Get(_columnDto.Id)).Returns(_column);

            _mockFactory = new Mock<IMapFactory>();
            _mockFactory.Setup(p => p.CreateAxisMap(_column, 0d, 1d)).Returns(_axisMap);

            _handler = new GetAxisMapQueryHandler(
                _mockRepository.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnMap()
        {
            var result = _handler.Execute(new GetAxisMapQuery(_columnDto.Id, 0d, 1d));
            Assert.That(result, Is.EqualTo(_axisMap));
        }
    }
}
