using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Label.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Label.Commands
{
    [TestFixture]
    public class UnsetLabelColumnCommandHandlerTests
        : BaseUnsetLayoutColumnCommandHandlerTests
    {
        private UnsetLabelColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new UnsetLabelColumnCommandHandler(
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetColumn()
        {
            _handler.Execute(new UnsetLabelColumnCommand());
            Assert.That(_layout.LabelColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new UnsetLabelColumnCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
