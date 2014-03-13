using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Domain.DataTypes.Detectors;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public class CsvFileDataAdapter : ICsvFileDataAdapter
    {
        private readonly ICsvFile _csvFile;
        private readonly ICsvFileParser _parser;
        private readonly IDataTypeDetector _dataTypeDetector;
        private readonly ISemanticTypeDetector _semanticTypeDetector;

        public CsvFileDataAdapter(
            ICsvFile csvFile,
            ICsvFileParser parser,
            IDataTypeDetector dataTypeDetector, 
            ISemanticTypeDetector semanticTypeDetector)
        {
            _csvFile = csvFile;
            _parser = parser;
            _dataTypeDetector = dataTypeDetector;
            _semanticTypeDetector = semanticTypeDetector;
        }

        public bool Exists(CsvFileSource source)
        {
            return _csvFile.Exists(source.FilePath);
        }

        public List<SourceColumn> GetColumns(CsvFileSource source)
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

        private List<SourceColumn> GetDataColumns(DataTable dataTable)
        {
            var dataColumns = new List<SourceColumn>();
           
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var values = dataTable.Rows.Cast<DataRow>()
                    .Select(p => p[i]).ToList();

                var dataType = _dataTypeDetector.Detect(values);

                var semanticType = _semanticTypeDetector.Detect(dataType, values);

                var columnName = dataTable.Columns[i].ColumnName;

                var dataColumn = new SourceColumn
                {
                    Name = columnName,
                    DataType = dataType,
                    SemanticType = semanticType
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
