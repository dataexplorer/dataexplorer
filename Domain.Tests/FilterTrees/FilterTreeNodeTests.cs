using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Tests.Application.FilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees
{
    [TestFixture]
    public class FilterTreeNodeTests
    {
        private FakeFilterTreeNode _node;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _node = new FakeFilterTreeNode("Test", _column);
        }

        [Test]
        public void TestGetNameShouldReturnName()
        {
            Assert.That(_node.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestGetColumnShouldReturnColumn()
        {
            Assert.That(_node.Column, Is.EqualTo(_column));
        }
    }
}
