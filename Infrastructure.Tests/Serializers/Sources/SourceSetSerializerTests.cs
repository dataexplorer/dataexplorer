using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.Serializers.Sources;
using DataExplorer.Tests.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Sources
{
    [TestFixture]
    public class SourceSetSerializerTests
    {
        private SourceSetSerializer _serializer;
        private Mock<ISourceSerializer> _mockSourceSerializer;
        private List<ISource> _sources;
        private ISource _source;
        private XElement _xSources;
        private XElement _xSource;

        [SetUp]
        public void SetUp()
        {
            _source = new FakeSource();
            _sources = new List<ISource> { _source };
            _xSource = new XElement("source");
            _xSources = new XElement("sources");
            _xSources.Add(_xSource);

            _mockSourceSerializer = new Mock<ISourceSerializer>();
            _mockSourceSerializer.Setup(p => p.Serialize(_source)).Returns(_xSource);
            _mockSourceSerializer.Setup(p => p.Deserialize(_xSource)).Returns(_source);

            _serializer = new SourceSetSerializer(_mockSourceSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldReturnSerializedSources()
        {
            var result = _serializer.Serialize(_sources);
            Assert.That(result.Name, Is.EqualTo(_xSources.Name));
            Assert.That(result.Elements().Single().Name, Is.EqualTo(_xSource.Name));
        }

        [Test]
        public void TestDeserializeShouldReturnDeserializedSources()
        {
            var result = _serializer.Deserialize(_xSources);
            Assert.That(result.Single(), Is.EqualTo(_source));
        }
    }
}
