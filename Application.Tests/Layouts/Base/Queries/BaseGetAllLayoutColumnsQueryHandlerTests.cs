using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Base.Queries
{
    public class BaseGetAllLayoutColumnsQueryHandlerTests
    {
        protected Mock<IColumnRepository> _mockRepository;
        protected Mock<IColumnAdapter> _mockAdapter;
        protected List<Column> _columns;
        protected ColumnDto _columnDto;

        public virtual void SetUp()
        {
            _columnDto = new ColumnDto();
            _columns = new List<Column>();

            _mockRepository = new Mock<IColumnRepository>();

            _mockAdapter = new Mock<IColumnAdapter>();
        }

        public void SetUpColumn(Column column)
        {
            _columns.Add(column);

            _mockRepository.Setup(p => p.GetAll())
                .Returns(_columns);

            _mockAdapter.Setup(p => p.Adapt(column))
                .Returns(_columnDto);
        }
    }
}
