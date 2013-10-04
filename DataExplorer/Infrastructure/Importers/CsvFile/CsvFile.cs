using System.IO;

namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public class CsvFile : ICsvFile
    {
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
