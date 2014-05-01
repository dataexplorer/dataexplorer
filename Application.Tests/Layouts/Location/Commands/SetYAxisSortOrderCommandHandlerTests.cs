using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Location.Commands
{
    [TestFixture]
    public class SetYAxisSortOrderCommandHandlerTests
        : BaseSetLayoutSortOrderCommandHandlerTests
    {
        private SetYAxisSortOrderCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new SetYAxisSortOrderCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetYAxisSortOrderCommand(SortOrder.Descending));
            Assert.That(_layout.YAxisSortOrder, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetYAxisSortOrderCommand(SortOrder.Descending));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
