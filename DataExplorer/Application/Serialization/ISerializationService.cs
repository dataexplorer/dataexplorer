using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.Serialization
{
    public interface ISerializationService
    {
        List<Column> GetColumns();
        List<Row> GetRows();
        List<IScatterPlot> GetViews();
    }
}
