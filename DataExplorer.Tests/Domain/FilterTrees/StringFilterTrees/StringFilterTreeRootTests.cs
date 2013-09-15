using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeRootTests
    {
        private StringFilterTreeRoot _root;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _root = new StringFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
