using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatFilterTreeFactoryTests
    {
        private FloatFilterTreeFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new FloatFilterTreeFactory();
        }

        [Test]
        public void TestCreateRootShouldCreateRoot()
        {
            var column = new ColumnBuilder().WithName("Test").Build();
            var result = _factory.CreateRoot(column);
            Assert.That(result.Name, Is.EqualTo("Test"));
        }
    }
}
