using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class BooleanToAxisMapTests
    {
        [Test]
        [TestCase(null, SortOrder.Ascending, null)]
        [TestCase(false, SortOrder.Ascending, 0d)]
        [TestCase(true, SortOrder.Ascending, 1d)]
        [TestCase(false, SortOrder.Descending, 1d)]
        [TestCase(true, SortOrder.Descending, 0d)]
        public void TestMapShouldReturnCorrectValues(bool? value, SortOrder sortOrder, double? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d, sortOrder);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, SortOrder.Ascending, null)]
        [TestCase(0d, SortOrder.Ascending, false)]
        [TestCase(0.5d, SortOrder.Ascending, true)]
        [TestCase(1d, SortOrder.Ascending, true)]
        [TestCase(0d, SortOrder.Descending, true)]
        [TestCase(0.5d, SortOrder.Descending, true)]
        [TestCase(1d, SortOrder.Descending, false)]
        public void TestMapInverseShouldReturnCorrectValues(double? value, SortOrder sortOrder, bool? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d, sortOrder);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
