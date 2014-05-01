using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.StringGridLines;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.StringGridLines
{
    [TestFixture]
    public class StringAxisGridLineFactoryTests
    {
        private StringGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new StringGridLineFactory();
        }

        [Test]
        public void TestCreateShouldReturnValues()
        {
            var sourceValues = new List<object> { "Ape", "Bat", "Cat", "Eel", "Fish" };
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count, Is.EqualTo(5));
            AssertGridLine(results.First(), 0.0d, "Ape");
            AssertGridLine(results.Last(), 1.0d, "Fish");
        }

        [Test]
        public void TestCreateShouldReturnDescendingValues()
        {
            var sourceValues = new List<object> { "Ape", "Bat", "Cat", "Eel", "Fish" };
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d, SortOrder.Descending);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count, Is.EqualTo(5));
            AssertGridLine(results.Last(), 1.0d, "Ape");
            AssertGridLine(results.First(), 0.0d, "Fish");
        }

        [Test]
        public void TestCreateShouldReturnAlphaValues()
        {
            var sourceValues = new List<object> { "Ape", "Bat", "Cat", "Eel", "Fish", "Gnat", "Hawk", "Ibis", "Jackal", "Kiwi", "Lion"};
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(11));
            AssertGridLine(results.First(), 0.0d, "A");
            AssertGridLine(results.Last(), 1.0d, "L");
        }

        [Test]
        public void TestCreateShouldReturnDescendingAlphaValues()
        {
            var sourceValues = new List<object> { "Ape", "Bat", "Cat", "Eel", "Fish", "Gnat", "Hawk", "Ibis", "Jackal", "Kiwi", "Lion" };
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d, SortOrder.Descending);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(11));
            AssertGridLine(results.First(), 1.0d, "A");
            AssertGridLine(results.Last(), 0.0d, "L");
        }

        private void AssertGridLine(AxisGridLine gridLine, double expectedPosition, string expectedLabel)
        {
            Assert.That(gridLine.Position, Is.EqualTo(expectedPosition));
            Assert.That(gridLine.LabelName, Is.EqualTo(expectedLabel));
        }
    }
}
