using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerFilterTreeFactoryTests
    {
        private IntegerFilterTreeFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new IntegerFilterTreeFactory();
        }

        [Test]
        public void TestCreateShouldCreateIntegerFilterTreeNode()
        {
            var column = new ColumnBuilder().WithName("Test").Build();
            var result = _factory.CreateRoot(column);
            Assert.That(result.Name, Is.EqualTo("Test"));
        }

    }
}
