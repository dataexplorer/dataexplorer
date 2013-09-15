using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerFilterTreeRootTests
    {
        private IntegerFilterTreeRoot _root;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _root = new IntegerFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
