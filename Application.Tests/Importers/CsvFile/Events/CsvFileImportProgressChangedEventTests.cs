using DataExplorer.Application.Importers.CsvFiles.Events;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Events
{
    [TestFixture]
    public class CsvFileImportProgressChangedEventTests
    {
        [Test]
        public void TestConstructorShouldSetProgress()
        {
            var @event = new SourceImportProgressChangedEvent(50);
            Assert.That(@event.Progress, Is.EqualTo(50));
        }
    }
}
