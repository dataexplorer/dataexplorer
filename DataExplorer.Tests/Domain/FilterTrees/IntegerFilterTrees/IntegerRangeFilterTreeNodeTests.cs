using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerRangeFilterTreeNodeTests
    {
        private IntegerFilterTreeRoot _root;

        [SetUp]
        public void SetUp()
        {
            _root = new IntegerFilterTreeRoot("Test");
        }

        [Test]
        public void TestConstructorShouldSetProperties()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
