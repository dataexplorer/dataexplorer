using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace DataExplorer.Application.Importers.CsvFile
{
    public interface ICsvFileParser
    {
        void OpenFile(string filePath);
        string[] ReadFields();
        bool IsEndOfFile();
        void CloseFile();
    }
}
