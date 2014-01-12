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
        private Mock<IGetAllColumnsQuery> _mockGetAllQuery;
        private Mock<IGetDistinctColumnValuesQuery> _mockGetValuesQuery;
        private ColumnDto _columnDto;
        private List<ColumnDto> _columnDtos;
        private List<object> _values;
        private object _value;

        [SetUp]
        public void SetUp()
        {
            _value = "Test";
            _values = new List<object> { _value };
            _columnDto = new ColumnDto();
            _columnDtos = new List<ColumnDto> { _columnDto };

            _mockGetAllQuery = new Mock<IGetAllColumnsQuery>();
            _mockGetAllQuery.Setup(p => p.Query()).Returns(_columnDtos);

            _mockGetValuesQuery = new Mock<IGetDistinctColumnValuesQuery>();
            _mockGetValuesQuery.Setup(p => p.Execute(_columnDto.Id)).Returns(_values);

            _service = new ColumnService(
                _mockGetAllQuery.Object,
                _mockGetValuesQuery.Object);
        }

        [Test]
        public void TestGetAllColumnsShouldExecuteQuery()
        {
            var result = _service.GetAllColumns();
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestGetDistinctValues()
        {
            var result = _service.GetDistinctColumnValues(_columnDto.Id);
            Assert.That(result.Single(), Is.EqualTo(_value));
        }
    }
}
