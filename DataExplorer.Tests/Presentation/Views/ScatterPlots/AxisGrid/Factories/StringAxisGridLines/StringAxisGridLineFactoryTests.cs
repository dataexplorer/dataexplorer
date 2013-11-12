using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.StringAxisGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGrid.Factories.StringAxisGridLines
{
    [TestFixture]
    public class StringAxisGridLineFactoryTests
    {
        private StringAxisGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new StringAxisGridLineFactory();
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
