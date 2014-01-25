using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Colors
{
    public class Color
    {
        private readonly byte _alpha;
        private readonly byte _red;
        private readonly byte _green;
        private readonly byte _blue;

        public Color(byte red, byte green, byte blue)
        {
            _alpha = 0;
            _red = red;
            _green = green;
            _blue = blue;
        }

        public byte Alpha
        {
            get { return _alpha; }
        }

        public byte Red
        {
            get { return _red; }
        }

        public byte Green
        {
            get { return _green; }
        }

        public byte Blue
        {
            get { return _blue; }
        }

        public static Color FromRgb(byte red, byte green, byte blue)
        {
            return new Color(red, green, blue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Color) obj);
        }

        protected bool Equals(Color other)
        {
            return _alpha == other._alpha 
                && _red == other._red 
                && _green == other._green 
                && _blue == other._blue;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _alpha.GetHashCode();
                hashCode = (hashCode * 397) ^ _red.GetHashCode();
                hashCode = (hashCode * 397) ^ _green.GetHashCode();
                hashCode = (hashCode * 397) ^ _blue.GetHashCode();
                return hashCode;
            }
        }
    }
}
