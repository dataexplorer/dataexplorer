using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeNodeTests
    {
        private StringFilterTreeRoot _root;

        [SetUp]
        public void SetUp()
        {
            _root = new StringFilterTreeRoot("Test");
        }

        [Test]
        public void TestConstructorShouldSetProperties()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
