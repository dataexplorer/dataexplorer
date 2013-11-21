using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Rows
{
    [TestFixture]
    public class RowTests
    {
        [Test]
        public void TestIndexerShouldReturnFieldAtIndex()
        {
            var row = new RowBuilder().WithField(1).Build();
            var result = row[0];
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
