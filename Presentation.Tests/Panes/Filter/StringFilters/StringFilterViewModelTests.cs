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
using DataExplorer.Presentation.Panes.Filter.StringFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.StringFilters
{
    [TestFixture]
    public class StringFilterViewModelTests
    {
        private StringFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private StringFilter _filter;
        private Column _column;
        private string _value;

        [SetUp]
        public void SetUp()
        {
            _value = "Test";
            _column = new ColumnBuilder().Build();
            _filter = new StringFilter(_column, string.Empty, false);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new StringFilterViewModel(
                _mockCommandBus.Object, _filter);
        }

        [Test]
        public void TestGetSetValueShouldGetSetValueInFilter()
        {
            _viewModel.Value = _value;
            Assert.That(_filter.Value, Is.EqualTo(_value));
        }

        [Test]
        public void TestSetValueShouldRaisePropertyChangedEvents()
        {
            AssertPropertyChanged(() => _viewModel.Value = _value, "Value");
        }

        [Test]
        public void TestSetLowerValueShouldExecuteUpdateFilterCommand()
        {
            _viewModel.Value = _value;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)),
                Times.Once());
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
