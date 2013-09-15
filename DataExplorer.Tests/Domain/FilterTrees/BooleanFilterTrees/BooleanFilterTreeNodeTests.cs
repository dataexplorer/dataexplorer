using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeNodeTests
    {
        private BooleanFilterTreeRoot _node;
        
        [SetUp]
        public void SetUp()
        {
            _node = new BooleanFilterTreeRoot("Test");
        }
        
        [Test]
        public void TestConstructorShouldSetProperties()
        {
            Assert.That(_node.Name, Is.EqualTo("Test"));
        }
    }
}
