using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Columns
{
    public class Column
    {
        private readonly int _id;
        private readonly int _index;
        private readonly string _name;
        private readonly Type _dataType;
        private readonly SemanticType _semanticType;
        private readonly List<object> _values;
        private readonly object _min;
        private readonly object _max;
        private readonly bool _hasNulls;

        public Column(
            int id, 
            int index, 
            string name, 
            Type dataType, 
            SemanticType semanticType, 
            List<object> values,
            object min,
            object max,
            bool hasNulls)
        {
            _id = id;
            _index = index;
            _name = name;
            _dataType = dataType;
            _semanticType = semanticType;
            _values = values;
            _min = min;
            _max = max;
            _hasNulls = hasNulls;
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

        public Type DataType
        {
            get { return _dataType; }
        }

        public SemanticType SemanticType
        {
            get { return _semanticType; }
        }

        public object Min
        {
            get { return _min; }
        }

        public object Max
        {
            get { return _max; }
        }

        public List<object> Values
        {
            get { return _values; }
        }

        public bool HasNulls
        {
            get { return _hasNulls; }
        }
    }
}
