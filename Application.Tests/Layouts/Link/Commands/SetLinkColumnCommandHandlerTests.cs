using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Link.Commands;
using DataExplorer.Application.Tests.Layouts.Base.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Link.Commands
{
    [TestFixture]
    public class SetLinkColumnCommandHandlerTests
        : BaseSetLayoutColumnCommandHandlerTests
    {
        private SetLinkColumnCommandHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new SetLinkColumnCommandHandler(
                _mockColumnRepository.Object,
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetLinkColumnCommand(_columnDto.Id));
            Assert.That(_layout.LinkColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetLinkColumnCommand(_columnDto.Id));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
