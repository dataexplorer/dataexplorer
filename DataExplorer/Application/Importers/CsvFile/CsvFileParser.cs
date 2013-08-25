using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileParser : ICsvFileParser
    {
        private TextFieldParser _parser;

        public void OpenFile(string filePath)
        {
            _parser = new TextFieldParser(filePath);
            _parser.TextFieldType = FieldType.Delimited;
            _parser.SetDelimiters( new string[] { "," });
        }

        public string[] ReadFields()
        {
            return _parser.ReadFields();
        }

        public bool IsEndOfFile()
        {
            return _parser.EndOfData;
        }

        public void CloseFile()
        {
            _parser.Close();
            _parser.Dispose();
        }
    }
}
