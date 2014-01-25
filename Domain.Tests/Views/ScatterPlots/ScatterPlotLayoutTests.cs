using System.Collections.Generic;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutTests
    {
        private ScatterPlotLayout _layout;
        private Column _column;
        public ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _colorPalette = new ColorPalette("Test", new List<Color>());

            _layout = new ScatterPlotLayout();
        }

        [Test]
        public void TestGetSetXAxisColumn()
        {
            _layout.XAxisColumn = _column;
            var result = _layout.XAxisColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetYAxisColumn()
        {
            _layout.YAxisColumn = _column;
            var result = _layout.YAxisColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetColorColumn()
        {
            _layout.ColorColumn = _column;
            var result = _layout.ColorColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetColorPalette()
        {
            _layout.ColorPalette = _colorPalette;
            var result = _layout.ColorPalette;
            Assert.That(result, Is.EqualTo(_colorPalette));
        }
        
        [Test]
        public void TestClearShouldClearLayout()
        {
            _layout.XAxisColumn = _column;
            _layout.YAxisColumn = _column;
            _layout.ColorColumn = _column;
            _layout.ColorPalette = _colorPalette;

            _layout.Clear();
            
            Assert.That(_layout.XAxisColumn, Is.Null);
            Assert.That(_layout.YAxisColumn, Is.Null);
            Assert.That(_layout.ColorColumn, Is.Null);
            Assert.That(_layout.ColorPalette, Is.Null);
        }
    }
}
