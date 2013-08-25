using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFile
{
    public interface ICsvFileAdapter
    {
        DataTable GetDataTable(CsvFileSource source);
        List<DataColumn> GetDataColumns(CsvFileSource source);
    }
}
