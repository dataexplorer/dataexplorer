using DataExplorer.Application.FilterTrees.Events;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees.Events
{
    [TestFixture]
    public class SelectedFilterTreeNodeChangedEventTests
    {
        [Test]
        public void TestGetNodeReturnsNode()
        {
            var node = new FakeFilterTreeNode();
            var @event = new SelectedFilterTreeNodeChangedEvent(node);
            Assert.That(@event.Node, Is.EqualTo(node));
        }
    }
}
