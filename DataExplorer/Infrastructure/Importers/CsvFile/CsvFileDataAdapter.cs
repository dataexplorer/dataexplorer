using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application.Importers;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public class CsvFileDataAdapter : ICsvFileDataAdapter
    {
        private readonly ICsvFile _csvFile;
        private readonly ICsvFileParser _parser;
        private readonly IDataTypeDetector _detector;

        public CsvFileDataAdapter(
            ICsvFile csvFile,
            ICsvFileParser parser,
            IDataTypeDetector detector)
        {
            _csvFile = csvFile;
            _parser = parser;
            _detector = detector;
        }

        public bool Exists(CsvFileSource source)
        {
            return _csvFile.Exists(source.FilePath);
        }

        public List<DataColumn> GetDataColumns(CsvFileSource source)
        {
            var dataTable = new DataTable();

            _parser.OpenFile(source.FilePath);

            ReadColumns(dataTable);

            ReadRows(dataTable);

            _parser.CloseFile();

            return GetDataColumns(dataTable);
        }

        public DataTable GetDataTable(CsvFileSource source)
        {
            var dataTable = new DataTable();

            _parser.OpenFile(source.FilePath);

            ReadColumns(dataTable);

            ReadRows(dataTable);

            _parser.CloseFile();

            return dataTable;
        }

        private List<DataColumn> GetDataColumns(DataTable dataTable)
        {
            var dataColumns = new List<DataColumn>();
           
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var values = dataTable.Rows.Cast<DataRow>()
                    .Select(p => p.Field<string>(i)).ToList();

                var type = _detector.Detect(values);

                var columnName = dataTable.Columns[i].ColumnName;

                var dataColumn = new DataColumn(columnName, type);
                
                dataColumns.Add(dataColumn);
            }
            return dataColumns;
        }

        private void ReadColumns(DataTable dataTable)
        {
            var headers = _parser.ReadFields();

            foreach (var header in headers)
            {
                var dataColumn = new DataColumn(header);

                dataTable.Columns.Add(dataColumn);
            }
        }

        private void ReadRows(DataTable dataTable)
        {
            while (!_parser.IsEndOfFile())
            {
                var row = dataTable.NewRow();

                var fields = _parser.ReadFields();
                
                for (int i = 0; i < fields.Length; i++)
                    row[i] = fields[i];
                
                dataTable.Rows.Add(row);
            }
        }
    }
}
