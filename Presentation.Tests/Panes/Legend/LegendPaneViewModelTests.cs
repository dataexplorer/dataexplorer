﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Legend;
using DataExplorer.Presentation.Panes.Legend.Colors;
using DataExplorer.Presentation.Panes.Legend.Sizes;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Legend
{
    [TestFixture]
    public class LegendPaneViewModelTests
    {
        private LegendPaneViewModel _viewModel;
        private Mock<IColorLegendViewModel> _mockColorLegendViewModel;
        private Mock<ISizeLegendViewModel> _mockSizeLegendViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockColorLegendViewModel = new Mock<IColorLegendViewModel>();
            _mockSizeLegendViewModel = new Mock<ISizeLegendViewModel>();

            _viewModel = new LegendPaneViewModel(
                _mockColorLegendViewModel.Object,
                _mockSizeLegendViewModel.Object);
        }

        [Test]
        public void TestGetColorLegendViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ColorLegendViewModel;
            Assert.That(result, Is.EqualTo(_mockColorLegendViewModel.Object));
        }

        [Test]
        public void TestGetSizeLegendViewModelShouldReturnViewModel()
        {
            var result = _viewModel.SizeLegendViewModel;
            Assert.That(result, Is.EqualTo(_mockSizeLegendViewModel.Object));
        }
    }
}
