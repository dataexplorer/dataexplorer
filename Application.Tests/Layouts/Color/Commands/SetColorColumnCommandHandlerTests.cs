using System;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Color.Commands
{
     [TestFixture]
    public class SetColorColumnCommandHandlerTests
        : BaseSetLayoutColumnCommandHandlerTests
    {
        private SetColorColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new SetColorColumnCommandHandler(
                _mockColumnRepository.Object,
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetColorColumnCommand(_columnDto.Id));
            Assert.That(_layout.ColorColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetColorColumnCommand(_columnDto.Id));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
