using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Application
{
    [TestFixture]
    public class ApplicationStateTests
    {
        private ApplicationState _state;

        [SetUp]
        public void SetUp()
        {
            _state = new ApplicationState();
        }

        [Test]
        public void TestConstructorShouldSetDefaultValues()
        {
            Assert.That(_state.IsStartMenuVisible, Is.True);
            Assert.That(_state.IsNavigationTreeVisible, Is.False);
            Assert.That(_state.SelectedFilter, Is.Null);
            Assert.That(_state.SelectedRows, Is.Empty);
        }
    }
}
