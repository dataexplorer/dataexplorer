using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Presentation.Panes.Filter.IntegerFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.IntegerFilters
{
    [TestFixture]
    public class IntegerRangeFilterViewModelTests
    {
        private IntegerRangeFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private IntegerFilter _filter;
        private Column _column;
        private int _value;

        [SetUp]
        public void SetUp()
        {
            _value = 1;
            _column = new ColumnBuilder()
                .WithValue(int.MinValue)
                .WithValue(int.MaxValue)
                .Build();
            _filter = new IntegerFilter(_column, int.MinValue, int.MaxValue, false);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new IntegerRangeFilterViewModel(
                _mockCommandBus.Object, _filter);
        }

        [Test]
        public void TestGetSetLowerValueShouldGetSetLowerValueInFilter()
        {
            _viewModel.LowerValue = _value;
            Assert.That(_filter.LowerValue, Is.EqualTo(_value));
        }

        [Test]
        public void TestSetLowerValueShouldRaisePropertyChangedEvents()
        {
            AssertPropertyChanged(() => _viewModel.LowerValue = int.MinValue, "LowerValue");
            AssertPropertyChanged(() => _viewModel.LowerValue = int.MinValue, "LowerSliderValue");
        }

        [Test]
        public void TestSetLowerValueShouldExecuteUpIntegerFilterCommand()
        {
            _viewModel.LowerValue = _value;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)),
                Times.Once());
        }

        [Test]
        public void TestGetSetUpperValueShouldGetSetUpperValueInFilter()
        {
            _viewModel.UpperValue = _value;
            Assert.That(_filter.UpperValue, Is.EqualTo(_value));
        }

        [Test]
        public void TestSetUpperValueShouldRaisePropertyChangedEvents()
        {
            AssertPropertyChanged(() => _viewModel.UpperValue = int.MinValue, "UpperValue");
            AssertPropertyChanged(() => _viewModel.UpperValue = int.MinValue, "UpperSliderValue");
        }

        [Test]
        public void TestSetUpperValueShouldExecuteUpIntegerFilterCommand()
        {
            _viewModel.UpperValue = _value;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)),
                Times.Once());
        }

        [Test]
        public void TestGetMinSliderValueShouldAlwaysReturnZero()
        {
            var result = _viewModel.MinSliderValue;
            Assert.That(result, Is.EqualTo(0.0d));
        }

        [Test]
        public void TestGetMaxSliderValueShouldAlwaysReturnOne()
        {
            var result = _viewModel.MaxSliderValue;
            Assert.That(result, Is.EqualTo(1.0d));
        }

        [Test]
        public void TestGetSetLowerSliderValue()
        {
            _viewModel.LowerSliderValue = 1;
            var result = _viewModel.LowerSliderValue;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestSetLowerValueShouldRaisePropertyChangedEvent()
        {
            AssertPropertyChanged(() => _viewModel.LowerSliderValue = 0.5d, "LowerValue");
            AssertPropertyChanged(() => _viewModel.LowerSliderValue = 0.5d, "LowerSliderValue");
        }

        [Test]
        public void TestGetSetUpperSliderValue()
        {
            _viewModel.UpperSliderValue = 1;
            var result = _viewModel.UpperSliderValue;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestSetUpperValueShouldRaisePropertyChangedEvent()
        {
            AssertPropertyChanged(() => _viewModel.UpperSliderValue = 0.5d, "UpperValue");
            AssertPropertyChanged(() => _viewModel.UpperSliderValue = 0.5d, "UpperSliderValue");
        }

        private void AssertPropertyChanged(Action action, string propertyName)
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == propertyName)
                    wasRaised = true;
            };
            action.Invoke();
            Assert.That(wasRaised, Is.True);
        }
    }
}
