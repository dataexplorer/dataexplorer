using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Columns
{
    public class Column
    {
        private readonly int _id;
        private readonly int _index;
        private readonly string _name;

        public Column(int id, int index, string name)
        {
            _id = id;
            _index = index;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
        }

        public int Index
        {
            get { return _index; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
