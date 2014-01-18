using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application
{
    public interface IDataContext
    {
        Dictionary<Type, Source> Sources { get; }
        
        List<Column> Columns { get; }

        List<Row> Rows { get; }

        List<Filter> Filters { get; }

        Dictionary<Type, View> Views { get; }

        Project GetProject();

        void SetProject(Project project);

        void Clear();
    }
}
