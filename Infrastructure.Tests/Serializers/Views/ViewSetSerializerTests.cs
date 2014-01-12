using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Views;
using DataExplorer.Domain.Views;
using DataExplorer.Infrastructure.Serializers.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Views
{
    [TestFixture]
    public class ViewSetSerializerTests
    {
        private ViewSetSerializer _serializer;
        private Mock<IViewSerializer> _mockViewSerializer;
        private List<IView> _views;
        private IView _view;
        private XElement _xViews;
        private XElement _xView;
        private List<Column> _columns;

        [SetUp]
        public void SetUp()
        {
            _view = new FakeView();
            _views = new List<IView> { _view };
            _columns = new List<Column>();

            _xView = new XElement("view");
            _xViews = new XElement("views");
            _xViews.Add(_xView);


            _mockViewSerializer = new Mock<IViewSerializer>();
            _mockViewSerializer.Setup(p => p.Serialize(_view)).Returns(_xView);
            _mockViewSerializer.Setup(p => p.Deserialize(_xView, _columns)).Returns(_view);

            _serializer = new ViewSetSerializer(_mockViewSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldReturnSerializedViews()
        {
            var result = _serializer.Serialize(_views);
            Assert.That(result.Name, Is.EqualTo(_xViews.Name));
            Assert.That(result.Elements().Single().Name, Is.EqualTo(_xView.Name));
        }

        [Test]
        public void TestDeserializeShouldReturnDeserializedViews()
        {
            var result = _serializer.Deserialize(_xViews, _columns);
            Assert.That(result.Single(), Is.EqualTo(_view));
        }
    }
}
