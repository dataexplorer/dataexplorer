using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Layouts.Link.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Link.Queries
{
    [TestFixture]
    public class GetAllLinkColumnsQueryHandlerTests
    {
        private GetAllLinkColumnsQueryHandler _handler;
        private Mock<IColumnRepository> _mockRepository;
        private Mock<IColumnAdapter> _mockAdapter;
        private List<Column> _columns;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _column = new ColumnBuilder()
                .WithSemanticType(SemanticType.Uri)
                .Build();
            _columns = new List<Column> { _column };

            _mockRepository = new Mock<IColumnRepository>();
            _mockRepository.Setup(p => p.GetAll())
                .Returns(_columns);

            _mockAdapter = new Mock<IColumnAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_column))
                .Returns(_columnDto);

            _handler = new GetAllLinkColumnsQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnAllUriColumns()
        {
            var result = _handler.Execute(new GetAllLinkColumnsQuery());
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestQueryShouldNotReturnAnyNonUriColumns()
        {
            _columns[0] = new ColumnBuilder()
                .WithSemanticType(SemanticType.Unknown)
                .Build();
            var result = _handler.Execute(new GetAllLinkColumnsQuery());
            Assert.That(result, Is.Empty);
        }
    }
}
