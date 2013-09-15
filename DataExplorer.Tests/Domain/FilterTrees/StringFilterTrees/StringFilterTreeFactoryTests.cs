using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeFactoryTests
    {
        private StringFilterTreeFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new StringFilterTreeFactory();
        }

        [Test]
        public void TestCreateShouldCreateStringFilterTreeNode()
        {
            var column = new ColumnBuilder().WithName("Test").Build();
            var result = _factory.CreateRoot(column);
            Assert.That(result.Name, Is.EqualTo("Test"));
        }
        
    }
}
