using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Domain.DataTypes.Detectors;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public class CsvFileDataAdapter : ICsvFileDataAdapter
    {
        private readonly ICsvFile _csvFile;
        private readonly ICsvFileParser _parser;
        private readonly IDataTypeDetector _dataTypeDetector;

        public CsvFileDataAdapter(
            ICsvFile csvFile,
            ICsvFileParser parser,
            IDataTypeDetector dataTypeDetector)
        {
            _csvFile = csvFile;
            _parser = parser;
            _dataTypeDetector = dataTypeDetector;
        }

        public bool Exists(CsvFileSource source)
        {
            return _csvFile.Exists(source.FilePath);
        }

        public List<DataColumn> GetColumns(CsvFileSource source)
        {
            var dataTable = new DataTable();

            _parser.OpenFile(source.FilePath);

            ReadColumns(dataTable);

            ReadRows(dataTable);

            _parser.CloseFile();

            return GetDataColumns(dataTable);
        }

        public DataTable GetTable(CsvFileSource source)
        {
            var dataTable = new DataTable();

            _parser.OpenFile(source.FilePath);

            ReadColumns(dataTable);

            ReadRows(dataTable);

            _parser.CloseFile();

            return dataTable;
        }

        // TODO: Should this method just return direct (i.e. non-infered) data types?
        // TODO: Or should I eliminate it all together?
        private List<DataColumn> GetDataColumns(DataTable dataTable)
        {
            var dataColumns = new List<DataColumn>();
           
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var values = dataTable.Rows.Cast<DataRow>()
                    .Select(p => p[i]).ToList();

                var dataType = _dataTypeDetector.Detect(values);

                var columnName = dataTable.Columns[i].ColumnName;

                var dataColumn = new DataColumn
                {
                    ColumnName = columnName,
                    DataType = dataType,
                };
                
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
