using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Columns
{
    [TestFixture]
    public class ColumnAdapterTests
    {
        private ColumnAdapter _adapter;

        [SetUp]
        public void SetUp()
        {
            _adapter = new ColumnAdapter();
        }

        [Test]
        public void TestAdaptShouldAdaptNullColumnToNullDto()
        {
            var result = _adapter.Adapt(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestAdaptShouldAdaptColumnToDto()
        {
            var column = new Column(1, 0, "Test");
            var result = _adapter.Adapt(column);
            Assert.That(result.Id, Is.EqualTo(column.Id));
            Assert.That(result.Index, Is.EqualTo(column.Index));
            Assert.That(result.Name, Is.EqualTo(column.Name));
        }
    }
}
