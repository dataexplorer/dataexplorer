using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public abstract class ColorMap
    {
        protected static Color NullColor = new Color(127, 127, 127);

        public abstract Color Map(object value);

        public abstract object MapInverse(Color value);
    }
}
