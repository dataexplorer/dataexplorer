using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Application.Projects;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Infrastructure.Serializers.Columns;
using DataExplorer.Infrastructure.Serializers.Filters;
using DataExplorer.Infrastructure.Serializers.Rows;
using DataExplorer.Infrastructure.Serializers.Sources;
using DataExplorer.Infrastructure.Serializers.Views;

namespace DataExplorer.Infrastructure.Serializers
{
    public class ProjectSerializer : IProjectSerializer
    {
        private static readonly string ProjectTag = "project";
        private static readonly string SourcesTag = "sources";
        private static readonly string ColumnsTag = "columns";
        private static readonly string FiltersTag = "filters";
        private static readonly string RowsTag = "rows";
        private static readonly string ViewsTag = "views";

        private readonly ISourceSetSerializer _sourceSetSerializer;
        private readonly IColumnDataTypeSerializer _columnDataTypeSerializer;
        private readonly IColumnSetSerializer _columnSetSerializer;
        private readonly IRowSetSerializer _rowSetSerializer;
        private readonly IFilterSetSerializer _filterSetSerializer;
        private readonly IViewSetSerializer _viewSetSerializer;

        public ProjectSerializer(
            ISourceSetSerializer sourceSetSerializer, 
            IColumnDataTypeSerializer columnDataTypeSerializer,
            IColumnSetSerializer columnSetSerializer, 
            IRowSetSerializer rowSetSerializer, 
            IFilterSetSerializer filterSetSerializer, 
            IViewSetSerializer viewSetSerializer)
        {
            _sourceSetSerializer = sourceSetSerializer;
            _columnDataTypeSerializer = columnDataTypeSerializer;
            _columnSetSerializer = columnSetSerializer;
            _rowSetSerializer = rowSetSerializer;
            _filterSetSerializer = filterSetSerializer;
            _viewSetSerializer = viewSetSerializer;
        }

        public XElement Serialize(Project project)
        {
            var xProject = new XElement(ProjectTag);

            SerializeSources(project, xProject);

            SerializeColumns(project, xProject);

            SerializeRows(project, xProject);

            SerializeFilters(project, xProject);

            SerializeViews(project, xProject);

            return xProject;
        }

        private void SerializeSources(Project project, XElement xProject)
        {
            var xSources = _sourceSetSerializer.Serialize(project.Sources);

            xProject.Add(xSources);
        }

        private void SerializeColumns(Project project, XElement xProject)
        {
            var xColumns = _columnSetSerializer.Serialize(project.Columns);
            
            xProject.Add(xColumns);
        }

        private void SerializeRows(Project project, XElement xProject)
        {
            var xRows = _rowSetSerializer.Serialize(project.Rows, project.Columns);
            
            xProject.Add(xRows);
        }

        private void SerializeFilters(Project project, XElement xProject)
        {
            var xFilters = _filterSetSerializer.Serialize(project.Filters);
            
            xProject.Add(xFilters);
        }

        private void SerializeViews(Project project, XElement xProject)
        {
            var xViews = _viewSetSerializer.Serialize(project.Views);

            xProject.Add(xViews);
        }

        public Project Deserialize(XElement xProject)
        {
            var sources = DeserializeSources(xProject);

            var columnDataTypes = DeserializeColumnDataTypes(xProject).ToList();

            var rows = DeserializeRows(xProject, columnDataTypes).ToList();

            var columns = DeserializeColumns(xProject, rows).ToList();

            var filters = DeserializeFilters(xProject, columns);

            var views = DeserializeViews(xProject, columns);

            var project = CreateProject(sources, columns, rows, filters, views);

            return project;
        }

        private static Project CreateProject(
            IEnumerable<Source> sources, 
            IEnumerable<Column> columns, 
            IEnumerable<Row> rows, 
            IEnumerable<Filter> filters,
            IEnumerable<View> views)
        {
            var project = new Project()
            {
                Sources = sources.ToList(),
                Columns = columns.ToList(),
                Rows = rows.ToList(),
                Filters = filters.ToList(),
                Views = views.ToList()
            };
            return project;
        }

        private IEnumerable<Source> DeserializeSources(XElement xProject)
        {
            var xSources = xProject.Element(SourcesTag);
            
            var sources = _sourceSetSerializer.Deserialize(xSources);
            
            return sources;
        }

        private IEnumerable<Type> DeserializeColumnDataTypes(XElement xProject)
        {
            var xColumns = xProject.Element(ColumnsTag);

            var types = _columnDataTypeSerializer.Deserialize(xColumns);

            return types;
        }

        private IEnumerable<Column> DeserializeColumns(XElement xProject, List<Row> rows)
        {
            var xColumns = xProject.Element(ColumnsTag);
            
            var columns = _columnSetSerializer.Deserialize(xColumns, rows);
            
            return columns;
        }

        private IEnumerable<Row> DeserializeRows(XElement xProject, List<Type> dataTypes)
        {
            var xRows = xProject.Element(RowsTag);
            
            var rows = _rowSetSerializer.Deserialize(xRows, dataTypes);
            
            return rows;
        }

        private IEnumerable<Filter> DeserializeFilters(XElement xProject, IEnumerable<Column> columns)
        {
            var xFilters = xProject.Element(FiltersTag);
            
            var filters = _filterSetSerializer.Deserialize(xFilters, columns);
            
            return filters;
        }

        private IEnumerable<View> DeserializeViews(XElement xProject, IEnumerable<Column> columns)
        {
            var xViews = xProject.Element(ViewsTag);

            var views = _viewSetSerializer.Deserialize(xViews, columns);
            
            return views;
        }
    }
}
