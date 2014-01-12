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
        public void TestIdShouldReturnId()
        {
            var row = new RowBuilder().WithId(1).Build();
            Assert.That(row.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestFieldsShouldReturnFields()
        {
            var row = new RowBuilder().WithField("Field 1").Build();
            Assert.That(row.Fields.Single(), Is.EqualTo("Field 1"));
        }

        [Test]
        public void TestIndexerShouldReturnFieldAtIndex()
        {
            var row = new RowBuilder().WithField(1).Build();
            Assert.That(row[0], Is.EqualTo(1));
        }


    }
}
