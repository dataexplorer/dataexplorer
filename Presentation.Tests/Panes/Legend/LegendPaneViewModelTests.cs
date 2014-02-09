using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Legend;
using DataExplorer.Presentation.Panes.Legend.Colors;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Legend
{
    [TestFixture]
    public class LegendPaneViewModelTests
    {
        private LegendPaneViewModel _viewModel;
        private Mock<IColorLegendViewModel> _mockColorLegendViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockColorLegendViewModel = new Mock<IColorLegendViewModel>();

            _viewModel = new LegendPaneViewModel(
                _mockColorLegendViewModel.Object);
        }

        [Test]
        public void TestGetColorLegendViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ColorLegendViewModel;
            Assert.That(result, Is.EqualTo(_mockColorLegendViewModel.Object));
        }
    }
}
