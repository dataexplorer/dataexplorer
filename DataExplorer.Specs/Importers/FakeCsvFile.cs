using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Specs.Importers
{
    public class FakeCsvFile
    {
        private List<string[]> _rows;
        private int _index = 0;

        public FakeCsvFile()
        {
            _rows = new List<string[]>();
        }

        public void Open()
        {
            _index = 0;
        }

        public void AddRow(string[] row)
        {
            _rows.Add(row);
        }

        public string[] GetRow()
        {
            return _rows[_index++];
        }

        public bool IsEndOfFile()
        {
            return _index == _rows.Count();
        }

        public void Close()
        {
            _index = 0;
        }
    }
}
