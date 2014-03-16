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
            if (dataType == typeof(BitmapImage))
                return CreateBitmapImageColumn(id, index, name, dataType, semanticType, values);

            var orderedValues = values
                .OrderBy(p => p)
                .ToList();

            return CreateComparableColumn(id, index, name, dataType, semanticType, orderedValues);
        }

        private Column CreateComparableColumn(
            int id, 
            int index, 
            string name, 
            Type dataType, 
            SemanticType semanticType, 
            List<object> orderedValues)
        {
            var min = orderedValues.Min();

            var max = orderedValues.Max();

            var hasNulls = orderedValues
                .Any(p => p == null);

            var column = new Column(
               id,
               index,
               name,
               dataType,
               semanticType,
               orderedValues,
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
