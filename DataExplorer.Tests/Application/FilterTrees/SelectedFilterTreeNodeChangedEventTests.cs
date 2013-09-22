using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FilterTrees
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
