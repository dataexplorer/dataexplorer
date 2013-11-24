using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Exporters.TabFile;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Exporters.TabFile
{
    [TestFixture]
    public class TabExporterTests
    {
        private TabExporter _exporter;
        private List<Column> _columns;
        private Column _column1;
        private Column _column2;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _column1 = new ColumnBuilder().WithName("Column 1").Build();
            _column2 = new ColumnBuilder().WithName("Column 2").Build();
            _columns = new List<Column> { _column1, _column2 };
            _row = new RowBuilder().WithField("Field 1").WithField("Field 2").Build();
            _rows = new List<Row> { _row };

            _exporter = new TabExporter();

        }

        [Test]
        public void TestExportShouldExportColumnHeaders()
        {
            var result = _exporter.Export(_columns, _rows);
            var line = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[0];
            Assert.That(line, Is.EqualTo("Column 1\tColumn 2"));
        }

        [Test]
        public void TestExportShouldExportFields()
        {
            var result = _exporter.Export(_columns, _rows);
            var line = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[1];
            Assert.That(line, Is.EqualTo("Field 1\tField 2"));
        }
    }
}
