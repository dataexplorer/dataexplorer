using DataExplorer.Application.Columns;
using DataExplorer.Presentation.Core.Layout;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Layout
{
    [TestFixture]
    public class LayoutItemViewModelTests
    {
        private LayoutItemViewModel _viewModel;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto { Name = "Test" };
            _viewModel = new LayoutItemViewModel(_columnDto);
        }

        [Test]
        public void TestGetNameShouldReturnColumnName()
        {
            var result = _viewModel.Name;
            Assert.That(result, Is.EqualTo("Test"));
        }

        [Test]
        public void TestGetColumnShouldReturnColumn()
        {
            var result = _viewModel.Column;
            Assert.That(result, Is.EqualTo(_columnDto));
        }
    }
}
