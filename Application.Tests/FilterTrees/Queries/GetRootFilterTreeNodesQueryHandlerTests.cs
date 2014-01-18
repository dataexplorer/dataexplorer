using System.Collections.Generic;
using DataExplorer.Application.Columns;
using DataExplorer.Application.FilterTrees.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.FilterTrees;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.FilterTrees.Queries
{
    [TestFixture]
    public class GetRootFilterTreeNodesQueryHandlerTests
    {
        private GetRootFilterTreeNodesQueryHandler _handler;
        private Mock<IColumnRepository> _mockRepository;
        private Mock<IFilterTreeNodeFactory> _mockFactory;
        private Column _column;
        private List<Column> _columns;
        private FakeFilterTreeNode _value;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _columns = new List<Column> { _column };
            _value = new FakeFilterTreeNode();

            _mockRepository = new Mock<IColumnRepository>();
            _mockRepository.Setup(p => p.GetAll()).Returns(_columns);

            _mockFactory = new Mock<IFilterTreeNodeFactory>();
            _mockFactory.Setup(p => p.CreateRoot(_column)).Returns(_value);
            
            _handler = new GetRootFilterTreeNodesQueryHandler(
                _mockRepository.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestGetRootFilterTreeNodesShouldReturnNodes()
        {
            var result = _handler.Execute(new GetRootFilterTreeNodesQuery());
            Assert.That(result, Contains.Item(_value));
        }
    }
}
