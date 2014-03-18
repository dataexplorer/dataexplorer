using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Shape.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Shape.Commands
{
    [TestFixture]
    public class UnsetShapeColumnCommandHandlerTests
        : BaseUnsetLayoutColumnCommandHandlerTests
    {
        private UnsetShapeColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new UnsetShapeColumnCommandHandler(
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldUnsetColumn()
        {
            _handler.Execute(new UnsetShapeColumnCommand());
            Assert.That(_layout.ShapeColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new UnsetShapeColumnCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
