using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Color.Commands
{
    [TestFixture]
    public class SetColorSortOrderCommandHandlerTests
        : BaseSetLayoutSortOrderCommandHandlerTests
    {
        private SetColorSortOrderCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new SetColorSortOrderCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetColorSortOrderCommand(SortOrder.Descending));
            Assert.That(_layout.ColorSortOrder, Is.EqualTo(SortOrder.Descending));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetColorSortOrderCommand(SortOrder.Descending));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
