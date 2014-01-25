using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Tests.Colors
{
    public class ColorPaletteBuilder
    {
        private string _name;
        private readonly List<Color> _colors;

        public ColorPaletteBuilder()
        {
            _name = string.Empty;
            _colors = new List<Color>();
        }

        public ColorPaletteBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ColorPaletteBuilder WithColor(Color color)
        {
            _colors.Add(color);
            return this;
        }

        public ColorPalette Build()
        {
            return new ColorPalette(_name, _colors);
        }
    }
}
