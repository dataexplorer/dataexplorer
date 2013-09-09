using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFile : ICsvFile
    {
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
