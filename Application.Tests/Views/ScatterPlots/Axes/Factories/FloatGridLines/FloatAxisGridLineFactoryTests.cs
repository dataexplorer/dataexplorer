using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.FloatGridLines;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.FloatGridLines
{
    [TestFixture]
    public class FloatAxisGridLineFactoryTests
    {
        private FloatGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new FloatGridLineFactory();
        }

        [Test]
        public void TestCreateShouldCreateMinAndMaxValues()
        {
            var map = new FloatToAxisMap(double.MinValue, double.MaxValue, 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            AssertGridLine(results[0], 0.0d, "-1.80E+308");
            AssertGridLine(results[1], 1.0d, "1.80E+308");
        }

        [Test]
        public void TestCreateShouldCreateDescendingValues()
        {
            var map = new FloatToAxisMap(-10d, 10d, 0d, 1d, SortOrder.Descending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            AssertGridLine(results.First(), 1.0d, "-10.00");
            AssertGridLine(results.Last(), 0.0d, "10.00");
        }

        [Test]
        [TestCase(-1000000000, 0, 11, "-1.00E+009", "0.00")]
        [TestCase(-1000000, 0, 11, "-1.00E+006", "0.00")]
        [TestCase(-1000, 0, 11, "-1,000.00", "0.00")]
        [TestCase(-10, 0, 11, "-10.00", "0.00")]
        [TestCase(0, 10, 11, "0.00", "10.00")]
        [TestCase(0, 1000, 11, "0.00", "1,000.00")]
        [TestCase(0, 1000000, 11, "0.00", "1.00E+006")]
        [TestCase(0, 1000000000, 11, "0.00", "1.00E+009")]
        [TestCase(0, 0.0001, 11, "0.00", "1.00E-004")]
        [TestCase(0, 0.000001, 11, "0.00", "1.00E-006")]
        [TestCase(0, 0.000000001, 11, "0.00", "1.00E-009")]
        public void TestCreateShouldCreateCorrectValues(double min, double max, int count, string lowerLabel, string upperLabel)
        {
            var map = new FloatToAxisMap(min, max, 0d, 1d, SortOrder.Ascending);
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
