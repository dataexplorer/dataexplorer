using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class AxisMapTests
    {
        [Test]
        public void TestSortOrderReturnsSortOrder()
        {
            var map = new FakeAxisMap(SortOrder.Descending);
            var result = map.SortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
