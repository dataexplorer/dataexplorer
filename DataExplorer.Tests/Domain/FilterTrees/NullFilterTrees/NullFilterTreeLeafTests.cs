using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.NullFilterTrees
{
    [TestFixture]
    public class NullFilterTreeLeafTests
    {
        private NullFilterTreeLeaf _leaf;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _leaf = new NullFilterTreeLeaf(string.Empty, _column);
        }

        [Test]
        public void TestCreateChildrenShouldReturnEmptyList()
        {
            var result = _leaf.CreateChildren();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            var result = _leaf.CreateFilter();
            Assert.That(result, Is.Not.Null);
        }
    }
}
