using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Link.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Link.Queries
{
    [TestFixture]
    public class GetAllLinkColumnsQueryHandlerTests
        : BaseGetAllLayoutColumnsQueryHandlerTests
    {
        private GetAllLinkColumnsQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new GetAllLinkColumnsQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        [TestCase(SemanticType.Uri)]
        public void TestExecuteShouldIncludeColumnTypes(SemanticType semanticType)
        {
            var column = new ColumnBuilder()
                .WithSemanticType(semanticType)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllLinkColumnsQuery());
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }

        [Test]
        [TestCase(SemanticType.Category)]
        [TestCase(SemanticType.Image)]
        [TestCase(SemanticType.Measure)]
        [TestCase(SemanticType.Name)]
        [TestCase(SemanticType.Unknown)]
        public void TestExecuteShouldExcludeColumnTypes(SemanticType semanticType)
        {
            var column = new ColumnBuilder()
                .WithSemanticType(semanticType)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllLinkColumnsQuery());
            Assert.That(result, Is.Empty);
        }
    }
}
