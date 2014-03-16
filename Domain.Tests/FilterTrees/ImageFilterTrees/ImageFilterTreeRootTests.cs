using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees.ImageFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.ImageFilterTrees
{
    [TestFixture]
    public class ImageFilterTreeRootTests
    {
        private ImageFilterTreeRoot _root;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _root = new ImageFilterTreeRoot("Test", _column);
        }

        [Test]
        public void TestCreateChildrenShouldCreateNullLeaf()
        {
            var results = _root.CreateChildren();
            Assert.That(results.Single().Name, Is.EqualTo("Null"));
        }

        [Test]
        public void TestCreateFilterShouldReturnImageFilter()
        {
            var result = (ImageFilter) _root.CreateFilter();
            Assert.That(result.Column, Is.EqualTo(_column));
        }
    }
}
