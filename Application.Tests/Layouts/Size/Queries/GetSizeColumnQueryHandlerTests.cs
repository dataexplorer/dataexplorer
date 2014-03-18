using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Queries
{
    [TestFixture]
    public class GetSizeColumnQueryHandlerTests
        : BaseGetLayoutColumnQueryHandlerTests
    {
        private GetSizeColumnQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _layout.SizeColumn = _column;

            _handler = new GetSizeColumnQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnColumnDto()
        {
            var result = _handler.Execute(new GetSizeColumnQuery());
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
