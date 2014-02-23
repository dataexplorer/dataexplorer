using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.FloatGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
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
            var map = new FloatToAxisMap(double.MinValue, double.MaxValue, 0d, 1d);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results[0].Position, Is.EqualTo(0d).Within(0.1));
            Assert.That(results[0].LabelName, Is.EqualTo("-1.80E+308"));
            Assert.That(results[1].Position, Is.EqualTo(1d).Within(0.1));
            Assert.That(results[1].LabelName, Is.EqualTo("1.80E+308"));
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
            var map = new FloatToAxisMap(min, max, 0d, 1d);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001));
            Assert.That(results.First().LabelName, Is.EqualTo(lowerLabel));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001));
            Assert.That(results.Last().LabelName, Is.EqualTo(upperLabel));
        }
    }
}
