using DataExplorer.Application.Columns;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Columns
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
            var column = new ColumnBuilder()
                .WithId(1)
                .WithIndex(0)
                .WithName("Test")
                .WithType(typeof(bool))
                .Build();
            var result = _adapter.Adapt(column);
            Assert.That(result.Id, Is.EqualTo(column.Id));
            Assert.That(result.Index, Is.EqualTo(column.Index));
            Assert.That(result.Name, Is.EqualTo(column.Name));
            Assert.That(result.Type, Is.EqualTo(column.Type));
        }
    }
}
