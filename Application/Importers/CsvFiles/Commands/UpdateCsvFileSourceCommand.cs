using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public class UpdateCsvFileSourceCommand : ICommand
    {
        private readonly string _filePath;

        public UpdateCsvFileSourceCommand(string filePath)
        {
            _filePath = filePath;
        }

        public string FilePath
        {
            get { return _filePath; }
        }
    }
}
