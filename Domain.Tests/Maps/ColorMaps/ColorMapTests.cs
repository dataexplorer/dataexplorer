using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.ColorMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    [TestFixture]
    public class ColorMapTests
    {
        [Test]
        public void TestSortOrderShouldReturnSortOrder()
        {
            var map = new FakeColorMap(SortOrder.Descending);
            var result = map.SortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }
    }
}
