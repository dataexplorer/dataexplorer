using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Domain.Columns
{
    public class ColumnFactory : IColumnFactory
    {
        public Column Create(
            int id,
            int index,
            string name,
            Type dataType,
            SemanticType semanticType,
            List<object> values)
        {
            return dataType == typeof(BitmapImage) 
                ? CreateBitmapImageColumn(id, index, name, dataType, semanticType, values) 
                : CreateComparableColumn(id, index, name, dataType, semanticType, values);
        }

        private Column CreateComparableColumn(
            int id, 
            int index, 
            string name, 
            Type dataType, 
            SemanticType semanticType, 
            List<object> values)
        {
            var distinctOrderedValues = values
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            var min = distinctOrderedValues.Min();

            var max = distinctOrderedValues.Max();

            var hasNulls = distinctOrderedValues
                .Any(p => p == null);

            var column = new Column(
               id,
               index,
               name,
               dataType,
               semanticType,
               distinctOrderedValues,
               min,
               max,
               hasNulls);

            return column;
        }
        
        private Column CreateBitmapImageColumn(
            int id,
            int index,
            string name,
            Type dataType,
            SemanticType semanticType,
            List<object> values)
        {
            var hasNulls = values
                .Any(p => p == null);

            var column = new Column(
                id,
                index,
                name,
                dataType,
                semanticType,
                values,
                null,
                null,
                hasNulls);

            return column;
        }
    }
}
