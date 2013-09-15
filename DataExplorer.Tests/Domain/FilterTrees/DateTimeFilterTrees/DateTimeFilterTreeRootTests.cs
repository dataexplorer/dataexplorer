using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class DateTimeFilterTreeRootTests
    {
        private DateTimeFilterTreeRoot _root;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _root = new DateTimeFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
