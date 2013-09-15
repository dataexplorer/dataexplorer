using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeRootTests
    {
        private BooleanFilterTreeRoot _node;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _node = new BooleanFilterTreeRoot("Test", _column);
        }
        
        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_node.Name, Is.EqualTo("Test"));
        }
    }
}
