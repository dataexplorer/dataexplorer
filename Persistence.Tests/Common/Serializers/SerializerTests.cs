using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Common.Serializers
{
    public class SerializerTests
    {
        public void AssertValue(XElement result, string name, string value)
        {
            Assert.That(result.Elements().First(p => p.Name.LocalName == name).Value,
                Is.EqualTo(value));
        }
    }
}
