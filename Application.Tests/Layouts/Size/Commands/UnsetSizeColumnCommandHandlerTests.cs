using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Commands
{
    [TestFixture]
    public class UnsetSizeColumnCommandHandlerTests
        : BaseUnsetLayoutColumnCommandHandlerTests
    {
        private UnsetSizeColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new UnsetSizeColumnCommandHandler(
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetColumn()
        {
            _handler.Execute(new UnsetSizeColumnCommand());
            Assert.That(_layout.SizeColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new UnsetSizeColumnCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
