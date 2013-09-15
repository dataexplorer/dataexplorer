using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatRangeFilterTreeNodeTests
    {
        private FloatFilterTreeRoot _root;

        [SetUp]
        public void SetUp()
        {
            _root = new FloatFilterTreeRoot("Test");
        }

        [Test]
        public void TestConstructorShouldSetProperties()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
