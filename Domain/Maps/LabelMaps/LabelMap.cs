using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public abstract class LabelMap
    {
        public abstract string Map(object value);

        //public abstract object MapInverse(string value);
    }
}
