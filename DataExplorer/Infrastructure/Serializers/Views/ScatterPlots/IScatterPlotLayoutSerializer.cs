using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Infrastructure.Serializers.Views.ScatterPlots
{
    public interface IScatterPlotLayoutSerializer
    {
        XElement Serialize(ScatterPlotLayout layout);

        ScatterPlotLayout Deserialize(XElement xLayout, IEnumerable<Column> columns);
    }
}
