using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatFilterTreeRootTests
    {
        private FloatFilterTreeRoot _root;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _root = new FloatFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
