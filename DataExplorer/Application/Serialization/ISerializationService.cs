using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.Serialization
{
    public interface ISerializationService
    {
        List<IScatterPlot> GetViews();
        List<Row> GetRows();
    }
}
