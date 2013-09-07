using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.CsvFile;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile
{
    [TestFixture]
    public class DataImportProgressChangedEventArgsTests
    {
        [Test]
        public void TestConstructorShouldSetProgressProperty()
        {
            var args = new DataImportProgressChangedEventArgs(50);
            Assert.That(args.Progress, Is.EqualTo(50));
        }
    }
}
