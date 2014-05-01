using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Commands
{
    [TestFixture]
    public class SetSizeSortOrderCommandHandlerTests
        : BaseSetLayoutSortOrderCommandHandlerTests
    {
        private SetSizeSortOrderCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new SetSizeSortOrderCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetSizeSortOrderCommand(SortOrder.Descending));
            Assert.That(_layout.SizeSortOrder, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetSizeSortOrderCommand(SortOrder.Descending));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
