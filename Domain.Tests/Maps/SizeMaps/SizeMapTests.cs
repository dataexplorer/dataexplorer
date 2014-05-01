using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class SizeMapTests
    {
        [Test]
        public void TestSortOrderShouldReturnSortOrder()
        {
            var map = new FakeSizeMap(SortOrder.Descending);
            var result = map.SortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
