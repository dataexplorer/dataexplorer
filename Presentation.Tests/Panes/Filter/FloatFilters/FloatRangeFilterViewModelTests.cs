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
using DataExplorer.Presentation.Panes.Filter.FloatFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.FloatFilters
{
    [TestFixture]
    public class FloatRangeFilterViewModelTests
    {
        private FloatRangeFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private FloatFilter _filter;
        private Column _column;
        private double _value;

        [SetUp]
        public void SetUp()
        {
            _value = 0.5d;
            _column = new ColumnBuilder()
                .WithValue(double.MinValue)
                .WithValue(double.MaxValue)
                .Build();
            _filter = new FloatFilter(_column, double.MinValue, double.MaxValue, false);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new FloatRangeFilterViewModel(
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
            AssertPropertyChanged(() => _viewModel.LowerValue = double.MinValue, "LowerValue");
            AssertPropertyChanged(() => _viewModel.LowerValue = double.MinValue, "LowerSliderValue");
        }

        [Test]
        public void TestSetLowerValueShouldExecuteUpFloatFilterCommand()
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
            AssertPropertyChanged(() => _viewModel.UpperValue = double.MinValue, "UpperValue");
            AssertPropertyChanged(() => _viewModel.UpperValue = double.MinValue, "UpperSliderValue");
        }

        [Test]
        public void TestSetUpperValueShouldExecuteUpFloatFilterCommand()
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
            _viewModel.LowerSliderValue = 0.5d;
            var result = _viewModel.LowerSliderValue;
            Assert.That(result, Is.EqualTo(0.50));
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
            _viewModel.UpperSliderValue = 0.5d;
            var result = _viewModel.UpperSliderValue;
            Assert.That(result, Is.EqualTo(0.50));
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
