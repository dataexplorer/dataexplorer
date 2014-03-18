using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Layouts.Label.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Label.Queries
{
    [TestFixture]
    public class GetLabelColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetLabelColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.LabelColumn = _column;

            _handler = new GetLabelColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetLabelColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
