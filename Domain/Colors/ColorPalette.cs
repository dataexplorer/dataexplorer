using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain
{
    public class ColorPalette
    {
        private readonly string _name;
        private readonly List<Color> _colors;

        public ColorPalette(string name, List<Color> colors)
        {
            _name = name;
            _colors = colors;
        }

        public string Name
        {
            get { return _name; }
        }

        public List<Color> Colors
        {
            get { return _colors; }
        }
    }
}
