using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers.CsvFile
{
    public interface ICsvFileImportService
    {
        event FilePathChangedEvent FilePathChanged;

        string GetFilePath();

        void SetFilePath(string filePath);
        
        void Import();
    }
}
