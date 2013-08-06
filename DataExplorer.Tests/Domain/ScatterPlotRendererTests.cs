using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlot;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain
{
    [TestFixture]
    public class ScatterPlotRendererTests
    {
        private ScatterPlotRenderer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new ScatterPlotRenderer();
        }

        [Test]
        public void TestRenderPlotsShouldRenderRowsIntoPlots()
        {
            var rows = new DataRowBuilder().WithValues(1, 2).BuildList();
            var results = _renderer.RenderPlots(rows);
            Assert.That(results.Single().X, Is.EqualTo(1.0));
            Assert.That(results.Single().Y, Is.EqualTo(2.0));
        }

        
    }
}
