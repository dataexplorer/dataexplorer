using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Columns
{
    public class Column
    {
        private readonly int _index;
        private readonly string _name;

        public Column(int index, string name)
        {
            _index = index;
            _name = name;
        }
    }
}
