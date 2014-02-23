using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Layouts.Queries;
using DataExplorer.Domain.Colors;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Queries
{
    [TestFixture]
    public class GetAllColorPalettesQueryHandlerTests
    {
        private GetAllColorPalettesQueryHandler _handler;
        private Mock<IColorPaletteFactory> _mockFactory;
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _colorPalette = new ColorPalette("Test", new List<Color>());

            _mockFactory = new Mock<IColorPaletteFactory>();
            _mockFactory.Setup(p => p.GetColorPalettes())
                .Returns(new List<ColorPalette> { _colorPalette });

            _handler = new GetAllColorPalettesQueryHandler(
                _mockFactory.Object);
        }

        [Test]
        public void TestExecuteShouldReturnAllColorPalettes()
        {
            var results = _handler.Execute(new GetAllColorPalettesQuery());
            Assert.That(results.Single(), Is.EqualTo(_colorPalette));
        }
    }
}
