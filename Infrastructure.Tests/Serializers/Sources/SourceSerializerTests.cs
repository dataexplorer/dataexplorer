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
    public class SourceSerializerTests
    {
        private SourceSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private CsvFileSource _source;
        private XElement _xSource;
        private XElement _xFilePath;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource() { FilePath = @"C:\Data.csv" };

            _xSource = new XElement("csv-file-source");
            _xFilePath = new XElement("file-path", @"C:\Data.csv");
            _xSource.Add(_xFilePath);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("file-path", _source.FilePath)).Returns(_xFilePath);
            _mockPropertySerializer.Setup(p => p.Deserialize<string>(_xFilePath)).Returns(_source.FilePath);

            _serializer = new SourceSerializer(_mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeSource()
        {
            var result = _serializer.Serialize(_source);
            Assert.That(result.Name.LocalName, Is.EqualTo("csv-file-source"));
        }

        [Test]
        public void TestSerializeShouldSerializeFilePath()
        {
            var result = _serializer.Serialize(_source);
            AssertValue(result, "file-path", _source.FilePath);
        }

        private void AssertValue(XElement result, string name, string value)
        {
            var actual = result.Elements()
                .Single(p => p.Name.LocalName == name).Value;
            Assert.That(actual, Is.EqualTo(value));
        }

        [Test]
        public void TestDeserializeShouldDeserializeFilePath()
        {
            var result = (CsvFileSource) _serializer.Deserialize(_xSource);
            Assert.That(result.FilePath, Is.EqualTo(_source.FilePath));
        }
    }
}
