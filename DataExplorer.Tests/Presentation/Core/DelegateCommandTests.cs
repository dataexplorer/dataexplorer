using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core
{
    [TestFixture]
    public class DelegateCommandTests
    {
        private DelegateCommand _delegateCommand;
        private Mock<ICommand> _mockCommand;

        [SetUp]
        public void SetUp()
        {
            _mockCommand = new Mock<ICommand>();
            _delegateCommand = new DelegateCommand(_mockCommand.Object.Execute, _mockCommand.Object.CanExecute);
        }

        [Test]
        public void TestIfExecuteIsNotInvokedThenActionShouldNotBeInvoked()
        {
            _mockCommand.Verify(p => p.Execute(null), Times.Never());
        }

        [Test]
        public void TestExecuteShouldInvokeAction()
        {
            _delegateCommand.Execute(null);
            _mockCommand.Verify(p => p.Execute(null), Times.Once());
        }

        [Test]
        public void TestCanExecuteShouldReturnTrueIfPredicateIsNull()
        {
            _delegateCommand = new DelegateCommand(_mockCommand.Object.Execute);
            var result = _delegateCommand.CanExecute(null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanExecuteShouldReturnTrueIfPredicateReturnsTrue()
        {
            _mockCommand.Setup(p => p.CanExecute(null)).Returns(true);
            var result = _delegateCommand.CanExecute(null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanExecuteShouldReturnFalseIfPredicateReturnsFalse()
        {
            _mockCommand.Setup(p => p.CanExecute(null)).Returns(false);
            var result = _delegateCommand.CanExecute(null);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestRaiseCanExecuteChangedShouldRaiseCanExecuteChangedEvent()
        {
            object sender = null;
            EventArgs args = null;
            _delegateCommand.CanExecuteChanged += (s, e) => { sender = s; args = e; };
            _delegateCommand.RaiseCanExecuteChanged();
            Assert.That(sender, Is.EqualTo(_delegateCommand));
            Assert.That(args, Is.EqualTo(EventArgs.Empty));
        }
    }
}
