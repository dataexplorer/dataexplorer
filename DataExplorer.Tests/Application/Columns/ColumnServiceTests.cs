using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Columns
{
    [TestFixture]
    public class ColumnServiceTests
    {
        private ColumnService _service;
        private Mock<IGetAllColumnsQuery> _mockQuery;
        private ColumnDto _columnDto;
        private List<ColumnDto> _columnDtos;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _columnDtos = new List<ColumnDto> { _columnDto };

            _mockQuery = new Mock<IGetAllColumnsQuery>();
            _mockQuery.Setup(p => p.Query()).Returns(_columnDtos);

            _service = new ColumnService(_mockQuery.Object);
        }

        [Test]
        public void TestGetAllColumnsShouldExecuteQuery()
        {
            var result = _service.GetAllColumns();
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }
    }
}
