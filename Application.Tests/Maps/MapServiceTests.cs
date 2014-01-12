using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Maps
{
    [TestFixture]
    public class MapServiceTests
    {
        private MapService _service;
        private Mock<IGetAxisMapQuery> _getAxisMapQuery;
        private ColumnDto _columnDto;
        private IAxisMap _axisMap;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _axisMap = new FakeAxisMap();

            _getAxisMapQuery = new Mock<IGetAxisMapQuery>();
            _getAxisMapQuery.Setup(p => p.Execute(_columnDto, 0d, 1d)).Returns(_axisMap);

            _service = new MapService(_getAxisMapQuery.Object);
        }

        [Test]
        public void TestGetAxisMapShouldReturnAxisMap()
        {
            var result = _service.GetAxisMap(_columnDto, 0d, 1d);
            Assert.That(result, Is.EqualTo(_axisMap));
        }
    }
}
