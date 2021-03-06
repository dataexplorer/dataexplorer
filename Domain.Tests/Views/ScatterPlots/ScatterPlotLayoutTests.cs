﻿using System.Collections.Generic;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
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
        public void TestGetSetXAxisReverse()
        {
            _layout.XAxisSortOrder = SortOrder.Descending;
            var result = _layout.XAxisSortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestGetSetYAxisColumn()
        {
            _layout.YAxisColumn = _column;
            var result = _layout.YAxisColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetYAxisReverse()
        {
            _layout.YAxisSortOrder = SortOrder.Descending;
            var result = _layout.YAxisSortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestGetSetColorColumn()
        {
            _layout.ColorColumn = _column;
            var result = _layout.ColorColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetColorReverse()
        {
            _layout.ColorSortOrder = SortOrder.Descending;
            var result = _layout.ColorSortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestGetSetColorPalette()
        {
            _layout.ColorPalette = _colorPalette;
            var result = _layout.ColorPalette;
            Assert.That(result, Is.EqualTo(_colorPalette));
        }

        [Test]
        public void TestGetSetSizeColumn()
        {
            _layout.SizeColumn = _column;
            var result = _layout.SizeColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetSizeReverse()
        {
            _layout.SizeSortOrder = SortOrder.Descending;
            var result = _layout.SizeSortOrder;
            Assert.That(result, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestGetSetShapeColumn()
        {
            _layout.ShapeColumn = _column;
            var result = _layout.ShapeColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetLabelColumn()
        {
            _layout.LabelColumn = _column;
            var result = _layout.LabelColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestGetSetLinkColumn()
        {
            _layout.LinkColumn = _column;
            var result = _layout.LinkColumn;
            Assert.That(result, Is.EqualTo(_column));
        }

        [Test]
        public void TestClearShouldClearLayout()
        {
            _layout.XAxisColumn = _column;
            _layout.XAxisSortOrder = SortOrder.Descending;
            _layout.YAxisColumn = _column;
            _layout.YAxisSortOrder = SortOrder.Descending;
            _layout.ColorColumn = _column;
            _layout.ColorSortOrder = SortOrder.Descending;
            _layout.ColorPalette = _colorPalette;
            _layout.SizeColumn = _column;
            _layout.SizeSortOrder = SortOrder.Descending;
            _layout.ShapeColumn = _column;
            _layout.LabelColumn = _column;
            _layout.LinkColumn = _column;

            _layout.Clear();
            
            Assert.That(_layout.XAxisColumn, Is.Null);
            Assert.That(_layout.XAxisSortOrder, Is.EqualTo(SortOrder.Ascending));
            Assert.That(_layout.YAxisColumn, Is.Null);
            Assert.That(_layout.YAxisSortOrder, Is.EqualTo(SortOrder.Ascending));
            Assert.That(_layout.ColorColumn, Is.Null);
            Assert.That(_layout.ColorSortOrder, Is.EqualTo(SortOrder.Ascending));
            Assert.That(_layout.ColorPalette.Name, Is.EqualTo("Pastel 1"));
            Assert.That(_layout.SizeColumn, Is.Null);
            Assert.That(_layout.SizeSortOrder, Is.EqualTo(SortOrder.Ascending));
            Assert.That(_layout.LowerSize, Is.EqualTo(0.125d));
            Assert.That(_layout.UpperSize, Is.EqualTo(0.125d));
            Assert.That(_layout.ShapeColumn, Is.Null);
            Assert.That(_layout.LabelColumn, Is.Null);
            Assert.That(_layout.LinkColumn, Is.Null);
        }
    }
}
