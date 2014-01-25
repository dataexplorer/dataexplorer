using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Colors
{
    public class ColorPaletteFactory : IColorPaletteFactory
    {
        #region Sequential color palettes
        public ColorPalette Reds = new ColorPalette("Reds", new List<Color>()
        {
            Color.FromRgb(255, 245, 240),
            Color.FromRgb(254, 224, 210),
            Color.FromRgb(252, 224, 210),
            Color.FromRgb(252, 146, 114),
            Color.FromRgb(251, 106, 74),
            Color.FromRgb(239, 59, 44),
            Color.FromRgb(203, 24, 29),
            Color.FromRgb(153, 0, 13)
        });

        public ColorPalette Oranges = new ColorPalette("Oranges", new List<Color>()
        {
            Color.FromRgb(255, 245, 235),
            Color.FromRgb(254, 230, 206),
            Color.FromRgb(253, 208, 162),
            Color.FromRgb(253, 174, 107),
            Color.FromRgb(253, 141, 60),
            Color.FromRgb(241, 105, 19),
            Color.FromRgb(217, 72, 1),
            Color.FromRgb(140, 45, 4)
        });

        public ColorPalette Greens = new ColorPalette("Greens", new List<Color>()
        {
            Color.FromRgb(247, 252, 245),
            Color.FromRgb(229, 245, 224),
            Color.FromRgb(199, 233, 192),
            Color.FromRgb(161, 217, 155),
            Color.FromRgb(116, 196, 118),
            Color.FromRgb(65, 171, 93),
            Color.FromRgb(35, 139, 69),
            Color.FromRgb(0, 90, 50)
        });

        public ColorPalette Blues = new ColorPalette("Blues", new List<Color>()
        {
            Color.FromRgb(247, 251, 255),
            Color.FromRgb(222, 235, 247),
            Color.FromRgb(198, 219, 239),
            Color.FromRgb(158, 202, 225),
            Color.FromRgb(107, 174, 214),
            Color.FromRgb(66, 146, 198),
            Color.FromRgb(3, 113, 181),
            Color.FromRgb(8, 69, 148),
        });

        public ColorPalette Purples  = new ColorPalette("Purples", new List<Color>()
        {
            Color.FromRgb(252, 251, 253),
            Color.FromRgb(239, 237, 245),
            Color.FromRgb(218, 218, 235),
            Color.FromRgb(188, 189, 220),
            Color.FromRgb(158, 154, 200),
            Color.FromRgb(128, 125, 186),
            Color.FromRgb(106, 81, 163),
            Color.FromRgb(74, 20, 134)
        });

        public ColorPalette Grays = new ColorPalette("Grays", new List<Color>()
        {
            Color.FromRgb(255, 255, 255),
            Color.FromRgb(240, 240, 240),
            Color.FromRgb(217, 217, 217),
            Color.FromRgb(189, 189, 189),
            Color.FromRgb(150, 150, 150),
            Color.FromRgb(115, 115, 115),
            Color.FromRgb(82, 82, 82),
            Color.FromRgb(37, 37, 37)
        }); 
        #endregion

        #region Divergent color palettes

        public ColorPalette Heat = new ColorPalette("Heat", new List<Color>()
        {
            Color.FromRgb(69, 117, 180),
            Color.FromRgb(116, 173, 209),
            Color.FromRgb(171, 217, 233),
            Color.FromRgb(224, 243, 248),
            Color.FromRgb(254, 224, 144),
            Color.FromRgb(253, 174, 97),
            Color.FromRgb(244, 109, 67),
            Color.FromRgb(215, 48, 39)
        });

        public ColorPalette Spectral = new ColorPalette("Spectral", new List<Color>()
        {
            Color.FromRgb(50, 136, 189),
            Color.FromRgb(102, 194, 165),
            Color.FromRgb(171, 221, 164),
            Color.FromRgb(230, 245, 152),
            Color.FromRgb(254, 224, 139),
            Color.FromRgb(253, 174, 97),
            Color.FromRgb(244, 109, 67),
            Color.FromRgb(213, 62, 79)
        });
        #endregion

        #region Categorical color palettes
        public ColorPalette Accent = new ColorPalette("Accent", new List<Color>()
        {
            Color.FromRgb(127, 201, 127),
            Color.FromRgb(190, 174, 212),
            Color.FromRgb(253, 192, 134),
            Color.FromRgb(255, 255, 153),
            Color.FromRgb(56, 108, 176),
            Color.FromRgb(240, 2, 127),
            Color.FromRgb(191, 91, 23),
            Color.FromRgb(102, 102, 102)
        });

        public ColorPalette Dark = new ColorPalette("Dark", new List<Color>()
        {
            Color.FromRgb(27, 158, 119),
            Color.FromRgb(217, 95, 2),
            Color.FromRgb(117, 112, 179),
            Color.FromRgb(231, 41, 138),
            Color.FromRgb(102, 166, 30),
            Color.FromRgb(230, 171, 2),
            Color.FromRgb(166, 118, 29),
            Color.FromRgb(102, 102, 102)
        });

        public ColorPalette Paired = new ColorPalette("Paired", new List<Color>()
        {
            Color.FromRgb(166, 206, 227),
            Color.FromRgb(31, 120, 180),
            Color.FromRgb(178, 223, 138),
            Color.FromRgb(51, 160, 44),
            Color.FromRgb(251, 154, 153),
            Color.FromRgb(227, 26, 28),
            Color.FromRgb(253, 191, 111),
            Color.FromRgb(255, 127, 0)
        });

        public ColorPalette Pastel1 = new ColorPalette("Pastel 1", new List<Color>()
        {
            Color.FromRgb(251, 180, 174),
            Color.FromRgb(179, 205, 227),
            Color.FromRgb(204, 235, 197),
            Color.FromRgb(222, 203, 228),
            Color.FromRgb(254, 217, 166),
            Color.FromRgb(255, 255, 204),
            Color.FromRgb(229, 216, 189),
            Color.FromRgb(253, 218, 236)
        });

        public ColorPalette Pastel2 = new ColorPalette("Pastel 2", new List<Color>()
        {
            Color.FromRgb(179, 226, 205),
            Color.FromRgb(253, 205, 172),
            Color.FromRgb(203, 213, 232),
            Color.FromRgb(244, 202, 228),
            Color.FromRgb(230, 245, 201),
            Color.FromRgb(255, 242, 174),
            Color.FromRgb(241, 226, 204),
            Color.FromRgb(204, 204, 204)
        });

        public ColorPalette Set1 = new ColorPalette("Set 1", new List<Color>()
        {
            Color.FromRgb(228, 26, 28),
            Color.FromRgb(55, 126, 184),
            Color.FromRgb(77, 175, 74),
            Color.FromRgb(152, 78, 163),
            Color.FromRgb(255, 127, 0),
            Color.FromRgb(255, 255, 51),
            Color.FromRgb(166, 86, 40),
            Color.FromRgb(247, 129, 191)
        });

        public ColorPalette Set2 = new ColorPalette("Set 2", new List<Color>()
        {
            Color.FromRgb(102, 194, 165),
            Color.FromRgb(252, 141, 98),
            Color.FromRgb(141, 160, 203),
            Color.FromRgb(231, 138, 195),
            Color.FromRgb(166, 216, 84),
            Color.FromRgb(255, 217, 47),
            Color.FromRgb(229, 196, 148),
            Color.FromRgb(179, 179, 179)
        });

        public ColorPalette Set3 = new ColorPalette("Set 3", new List<Color>()
        {
            Color.FromRgb(141, 211, 199),
            Color.FromRgb(255, 255, 179),
            Color.FromRgb(190, 186, 218),
            Color.FromRgb(251, 128, 114),
            Color.FromRgb(128, 177, 211),
            Color.FromRgb(253, 180, 98),
            Color.FromRgb(179, 222, 105),
            Color.FromRgb(252, 205, 229)
        });
        #endregion

         public ColorPalette GetColorPalette(string colorPaletteName)
        {
            var match = GetColorPalettes()
                .FirstOrDefault(p => p.Name == colorPaletteName);

            return match;
        }

        public List<ColorPalette> GetColorPalettes()
        {
            var fieldInfos = typeof(ColorPaletteFactory).GetFields();
            
            var colorPalettes = fieldInfos
                .ToList()
                .Select(p => p.GetValue(this))
                .Cast<ColorPalette>()
                .ToList();

            return colorPalettes;
        }
    }
}
