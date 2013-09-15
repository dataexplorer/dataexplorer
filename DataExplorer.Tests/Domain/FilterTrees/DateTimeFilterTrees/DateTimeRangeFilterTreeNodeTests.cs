using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class DateTimeRangeFilterTreeNodeTests
    {
        private DateTimeFilterTreeRoot _root;

        [SetUp]
        public void SetUp()
        {
            _root = new DateTimeFilterTreeRoot("Test");
        }

        [Test]
        public void TestConstructorShouldSetProperties()
        {
            Assert.That(_root.Name, Is.EqualTo("Test"));
        }
    }
}
