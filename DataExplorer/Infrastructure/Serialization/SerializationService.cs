using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;

namespace DataExplorer.Infrastructure.Serialization
{
    public class SerializationService : ISerializationService
    {
        public Project GetProject()
        {
            // TODO: Remove this fake data
            var project = new Project()
            {
                Sources = GetSources(),
                Columns = GetColumns(),
                Rows = GetRows(),
                Filters = GetFilters(),
                DataViews = GetViews()
            };

            return project;
        }

        private List<ISource> GetSources()
        {
            var source = new CsvFileSource();
            var sources = new List<ISource> { source };
            return sources;
        }

        private List<Column> GetColumns()
        {
            var column1 = new Column(1, 0, "Boolean", typeof(Boolean), GetRows().Select(p => p[0]).ToList());
            var column2 = new Column(2, 1, "DateTime", typeof(DateTime), GetRows().Select(p => p[1]).ToList());
            var column3 = new Column(3, 2, "Float", typeof(Double), GetRows().Select(p => p[2]).ToList());
            var column4 = new Column(4, 3, "Integer", typeof(Int32), GetRows().Select(p => p[3]).ToList());
            var column5 = new Column(5, 4, "String", typeof(String), GetRows().Select(p => p[4]).ToList());
            var columns = new List<Column> { column1, column2, column3, column4, column5 };
            return columns;
        }

        private List<Row> GetRows()
        {
            // TODO: Remove this fake data
            var row1 = new Row(1, new List<object>() { false, DateTime.Parse("1/1/0001"), 0d, 0, "Apple" });
            var row2 = new Row(2, new List<object>() { false, DateTime.Parse("10/1/2500"), 0.25d, 250, "Elephant" });
            var row3 = new Row(3, new List<object>() { false, DateTime.Parse("7/2/5000"), 0.5d, 500, "Monkey" });
            var row4 = new Row(4, new List<object>() { false, DateTime.Parse("4/2/7500"), 0.75d, 750, "Tiger" });
            var row5 = new Row(5, new List<object>() { true, DateTime.Parse("12/31/9999"), 1d, 1000, "Zebra" });
            var rows = new List<Row> { row1, row2, row3, row4, row5 };
            return rows;
        }

        private List<Filter> GetFilters()
        {
            return new List<Filter>();
        }

        private List<IView> GetViews()
        {
            // TODO: Remove this fake data
            //var plot1 = new Plot() { X = 0, Y = 0 };
            //var plot2 = new Plot() { X = 1000, Y = 1000 };
            //var plots = new List<Plot>() { plot1, plot2 };
            var scatterPlot = new ScatterPlot();
            return new List<IView>() { scatterPlot };
        }
    }
}
