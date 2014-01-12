using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Titles
{
    public class TitleQueriesTests
    {
        private TitleQueries _queries;
        private Mock<IGetXAxisTitleQuery> _mockXTitleQuery;
        private Mock<IGetYAxisTitleQuery> _mockYTitleQuery;
        private Size _controlSize;
        private CanvasLabel _label;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _label = new CanvasLabel();

            _mockXTitleQuery = new Mock<IGetXAxisTitleQuery>();
            _mockXTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_label);

            _mockYTitleQuery = new Mock<IGetYAxisTitleQuery>();
            _mockYTitleQuery.Setup(p => p.Execute(_controlSize)).Returns(_label);

            _queries = new TitleQueries(
                _mockXTitleQuery.Object,
                _mockYTitleQuery.Object);
        }

        [Test]
        public void TestGetXAxisTitleShouldReturnTitle()
        {
            var result = _queries.GetXAxisTitle(_controlSize);
            Assert.That(result, Is.EqualTo(_label));
        }

        [Test]
        public void TestGetYAxisTitleShouldReturnTitle()
        {
            var result = _queries.GetYAxisTitle(_controlSize);
            Assert.That(result, Is.EqualTo(_label));
        }
    }
}
