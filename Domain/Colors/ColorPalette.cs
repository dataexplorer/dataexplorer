using System;
using System.Collections.Generic;

namespace DataExplorer.Domain.Colors
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
