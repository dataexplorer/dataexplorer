using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Rows
{
    [TestFixture]
    public class RowServiceTests
    {
        private RowService _service;
        private Mock<IRowRepository> _mockRepository;
        private Mock<IApplicationStateService> _mockStateService;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };

            _mockRepository = new Mock<IRowRepository>();
            _mockRepository.Setup(p => p.GetAll()).Returns(_rows);

            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.SelectedRows).Returns(_rows);
            
            _service = new RowService(
                _mockRepository.Object,
                _mockStateService.Object);
        }

        [Test]
        public void TestGetAllShouldReturnAllRows()
        {
            var results = _service.GetAll();
            Assert.That(results.Single(), Is.EqualTo(_row));
        }

        [Test]
        public void TestSetSelectedRowsShouldSelectRows()
        {
            _service.SetSelectedRows(_rows);
            _mockStateService.VerifySet(p => p.SelectedRows = _rows);
        }

        [Test]
        public void TestGetSelectedRowsShouldGetSelectedRows()
        {
            var results = _service.GetSelectedRows();
            Assert.That(results.Single(), Is.EqualTo(_row));

        }
    }
}
