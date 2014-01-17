using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Infrastructure.Serializers.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Sources
{
    [TestFixture]
    public class SourceSerializerTests : SerializerTests
    {
        private SourceSerializer _serializer;
        private CsvFileSource _source;
        private XElement _xSource;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource() { FilePath = @"C:\Data.csv" };

            _xSource = new XElement("csv-file-source",
                new XElement("file-path", @"C:\Data.csv"));
            
            _serializer = new SourceSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializeProperties()
        {
            var result = _serializer.Serialize(_source);
            Assert.That(result.Name.LocalName, Is.EqualTo("csv-file-source"));
            AssertValue(result, "file-path", _source.FilePath);
        }
        
        [Test]
        public void TestDeserializeShouldDeserializeFilePath()
        {
            var result = (CsvFileSource) _serializer.Deserialize(_xSource);
            Assert.That(result.FilePath, Is.EqualTo(_source.FilePath));
        }
    }
}
