using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.CsvFiles.Events;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile.Events
{
    [TestFixture]
    public class CsvFileImportProgressChangedEventTests
    {
        [Test]
        public void TestConstructorShouldSetProgress()
        {
            var @event = new CsvFileImportProgressChangedEvent(50);
            Assert.That(@event.Progress, Is.EqualTo(50));
        }
    }
}
