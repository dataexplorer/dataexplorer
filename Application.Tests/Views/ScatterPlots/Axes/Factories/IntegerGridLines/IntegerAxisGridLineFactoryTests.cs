using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.IntegerGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
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
            var map = new IntegerToAxisMap(int.MinValue, int.MaxValue, 0d, 1d);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results[0].Position, Is.EqualTo(0d).Within(0.001));
            Assert.That(results[0].LabelName, Is.EqualTo("-2.15E+009"));
            Assert.That(results[1].Position, Is.EqualTo(1d).Within(0.001));
            Assert.That(results[1].LabelName, Is.EqualTo("2.15E+009"));
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
            var map = new IntegerToAxisMap(min, max, 0d, 1d);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(0d));
            Assert.That(results.First().LabelName, Is.EqualTo(lowerLabel));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
            Assert.That(results.Last().LabelName, Is.EqualTo(upperLabel));
        }
    }
}
