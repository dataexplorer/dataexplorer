using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.IntegerGridLines;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.IntegerGridLines
{
    [TestFixture]
    public class IntegerAxisGridLineFactoryTests
    {
        private IntegerGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new IntegerGridLineFactory();
        }

        [Test]
        public void TestCreateShouldCreateMinAndMaxValues()
        {
            var map = new IntegerToAxisMap(int.MinValue, int.MaxValue, 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            AssertGridLine(results[0], 0.0d, "-2.15E+009");
            AssertGridLine(results[1], 1.0d, "2.15E+009");
        }

        [Test]
        public void TestCreateShouldReverseValuesIfSortOrderIsDescending()
        {
            var map = new IntegerToAxisMap(-10, 10, 0d, 1d, SortOrder.Descending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            AssertGridLine(results.First(), 1.0d, "-10");
            AssertGridLine(results.Last(), 0.0d, "10");
        }

        [Test]
        [TestCase(-1000000000, 0, 11, "-1.00E+009", "0")]
        [TestCase(-1000000, 0, 11, "-1.00E+006", "0")]
        [TestCase(-1000, 0, 11, "-1000", "0")]
        [TestCase(-10, 0, 11, "-10", "0")]
        [TestCase(0, 10, 11, "0", "10")]
        [TestCase(0, 1000, 11, "0", "1000")]
        [TestCase(0, 1000000, 11, "0", "1.00E+006")]
        [TestCase(0, 1000000000, 11, "0", "1.00E+009")]
        public void TestCreateShouldCreateCorrectValues(int min, int max, int count, string lowerLabel, string upperLabel)
        {
            var map = new IntegerToAxisMap(min, max, 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(count));
            AssertGridLine(results.First(), 0.0d, lowerLabel);
            AssertGridLine(results.Last(), 1.0d, upperLabel);
        }

        private void AssertGridLine(AxisGridLine gridLine, double position, string label)
        {
            Assert.That(gridLine.Position, Is.EqualTo(position).Within(0.001));
            Assert.That(gridLine.LabelName, Is.EqualTo(label)); 
        }
    }
}
