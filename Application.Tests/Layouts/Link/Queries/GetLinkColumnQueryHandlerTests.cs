using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Layouts.Link.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Link.Queries
{
    [TestFixture]
    public class GetLinkColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetLinkColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.LinkColumn = _column;

            _handler = new GetLinkColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetLinkColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
