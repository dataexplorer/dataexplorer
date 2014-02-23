using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.StringGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
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
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count, Is.EqualTo(5));
            Assert.That(results.First().LabelName, Is.EqualTo("Ape"));
            Assert.That(results.Last().LabelName, Is.EqualTo("Fish"));
        }

        [Test]
        public void TestCreateShouldReturnAlphaValues()
        {
            var sourceValues = new List<object> { "Ape", "Bat", "Cat", "Eel", "Fish", "Gnat", "Hawk", "Ibis", "Jackal", "Kiwi", "Lion"};
            var map = new StringToAxisMap(sourceValues.Cast<string>().ToList(), 0d, 1d);
            var results = _factory.Create(map, sourceValues, 0d, 1d).ToList();
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().LabelName, Is.EqualTo("A"));
            Assert.That(results.Last().LabelName, Is.EqualTo("L"));
        }
    }
}
