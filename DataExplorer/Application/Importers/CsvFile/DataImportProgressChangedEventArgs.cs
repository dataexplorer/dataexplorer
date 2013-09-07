using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class DataImportProgressChangedEventArgs : EventArgs
    {
        private readonly double _progress;

        public DataImportProgressChangedEventArgs(double progress)
        {
            _progress = progress;
        }

        public double Progress
        {
            get { return _progress; }
        }
    }
}
