﻿using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Exporters
{
    public interface ITabExporter
    {
        string Export(IEnumerable<Column> columns, IEnumerable<Row> rows);
    }
}
