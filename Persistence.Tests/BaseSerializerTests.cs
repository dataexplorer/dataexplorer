using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests
{
    [TestFixture]
    public class BaseSerializerTests
    {
        private FakeSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private XElement _xParent;
        private XElement _xChild;
        private string _name;
        private bool _value;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _xParent = new XElement("Parent");
            _xChild = new XElement("Child");
            _name = "Child";
            _value = true;
            _column = new ColumnBuilder().WithId(1).Build();

            _mockPropertySerializer = new Mock<IPropertySerializer>();

            _serializer = new FakeSerializer(
                _mockPropertySerializer.Object);    
        }

        [Test]
        public void TestAddPropertyShouldAddProperty()
        {
            _mockPropertySerializer.Setup(p => p.Serialize(_name, _value))
                .Returns(_xChild);
            _serializer.AddProperty(_xParent, _name, _value);
            Assert.That(_xParent.Elements().Single(), Is.EqualTo(_xChild));
        }

        [Test]
        public void TestGetPropertyShouldReturnDefaultValueIfPropertyDoesNotExist()
        {
            _mockPropertySerializer.Setup(p => p.Deserialize<bool?>(_xChild))
                .Returns(_value);
            var result = _serializer.GetProperty<bool?>(_xParent, _name);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetPropertyShouldGetProperty()
        {
            _xParent.Add(_xChild);
            _mockPropertySerializer.Setup(p => p.Deserialize<bool?>(_xChild))
                .Returns(_value);
            var result = _serializer.GetProperty<bool?>(_xParent, _name);
            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void TestAddColumnShouldAddColumnId()
        {
            _mockPropertySerializer.Setup(p => p.Serialize<int?>(_name, _column.Id))
                .Returns(_xChild);
            _serializer.AddColumn(_xParent, _name, _column);
            Assert.That(_xParent.Elements().Single(), Is.EqualTo(_xChild));
        }

        [Test]
        public void TestGetColumnShouldReturnNullIfPropertyDoesNotExist()
        {
            _mockPropertySerializer.Setup(p => p.Deserialize<int?>(_xChild))
                .Returns(_column.Id);
            var result = _serializer.GetColumn(_xParent, _name, new List<Column> { _column });
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetColumnShouldGetColumn()
        {
            _xParent.Add(_xChild);
            _mockPropertySerializer.Setup(p => p.Deserialize<int?>(_xChild))
                .Returns(_column.Id);
            var result = _serializer.GetColumn(_xParent, _name, new List<Column> { _column });
            Assert.That(result, Is.EqualTo(_column));
        }
    }

    internal class FakeSerializer : BaseSerializer
    {
        public FakeSerializer(IPropertySerializer propertySerializer) : base(propertySerializer)
        {
        }

        public new void AddProperty<T>(XElement xParent, string name, T value)
        {
            base.AddProperty(xParent, name, value);
        }

        public new T GetProperty<T>(XElement xParent, string name)
        {
            return base.GetProperty<T>(xParent, name);
        }

        public new void AddColumn(XElement xParent, string name, Column column)
        {
            base.AddColumn(xParent, name, column);
        }

        public new Column GetColumn(XElement xParent, string name, List<Column> columns)
        {
            return base.GetColumn(xParent, name, columns);
        }
    }
}
