using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Color.Commands
{
    [TestFixture]
    public class UnsetColorColumnCommandHandlerTests
        : BaseUnsetLayoutColumnCommandHandlerTests
    {
        private UnsetColorColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new UnsetColorColumnCommandHandler(
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetColumn()
        {
            _handler.Execute(new UnsetColorColumnCommand());
            Assert.That(_layout.ColorColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new UnsetColorColumnCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
