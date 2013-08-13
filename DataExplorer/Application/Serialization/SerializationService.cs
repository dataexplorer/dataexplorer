using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.Serialization
{
    public class SerializationService : ISerializationService
    {
        

        public List<Row> GetRows()
        {
            // TODO: Remove this fake data
            var row1 = new Row(new List<object>() { 0, 0 });
            var row2 = new Row(new List<object>() { 1000, 0 });
            var row3 = new Row(new List<object>() { 0, 1000 });
            var row4 = new Row(new List<object>() { 1000, 1000 });
            var rows = new List<Row> { row1, row2, row3, row4 };
            return rows;
        }

        public List<IScatterPlot> GetViews()
        {
            // TODO: Remove this fake data
            //var plot1 = new Plot() { X = 0, Y = 0 };
            //var plot2 = new Plot() { X = 1000, Y = 1000 };
            //var plots = new List<Plot>() { plot1, plot2 };
            var scatterPlot = new Domain.ScatterPlots.ScatterPlot();
            return new List<IScatterPlot>() { scatterPlot };
        }
    }
}
